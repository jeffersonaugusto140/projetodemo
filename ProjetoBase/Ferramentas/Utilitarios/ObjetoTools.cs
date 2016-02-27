using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Ferramentas
{
    public static class ObjetoTools
    {
        public static TSource Clonar<TSource>(this TSource objetoDe)
        {
            TSource objetoPara = CriarInstancia<TSource>();

            return objetoDe.CopiarPara(objetoPara);
        }

        public static TSource CopiarPara<TSource>(this TSource objetoDe, TSource objetoPara)
        {
            PropertyInfo[] mArrayTargetProperty = objetoPara.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo targetProperty in mArrayTargetProperty)
            {
                PropertyInfo sourcetProperty = objetoDe.GetType().GetProperty(targetProperty.Name, targetProperty.PropertyType);

                if (sourcetProperty != null)
                    targetProperty.SetValue(objetoPara, sourcetProperty.GetValue(objetoDe, null), null);
            }

            return objetoPara;
        }

        public static TSource CriarInstancia<TSource>(params object[] args)
        {
            try
            {
                Type type = typeof(TSource);
                Assembly mAssembly = type.Assembly;
                return (TSource)mAssembly.CreateInstance(type.FullName, true, BindingFlags.CreateInstance, null, args, null, null);
            }
            catch (Exception ex)
            {
                throw new System.TypeUnloadedException(
                    string.Format("Não foi possível criar instância do objeto '{0}'", typeof(TSource).FullName), ex);
            }
        }

        public static object CriarInstancia(Type pType, params object[] args)
        {
            try
            {
                Assembly mAssembly = pType.Assembly;
                return mAssembly.CreateInstance(pType.FullName, true, BindingFlags.CreateInstance, null, args, null, null);
            }
            catch (System.Exception ex)
            {
                throw new System.TypeUnloadedException(string.Format("Não foi possível criar instância do objeto '{0}'", pType.FullName), ex);
            }
        }

        public static bool EhNuloOuVazio<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static bool EhNuloOuVazio(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool EhNulo(this object o)
        {
            return o == null;
        }

        public static object BuscarId(object entity)
        {
            try
            {
                PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo propertyInfo in properties)
                    if (propertyInfo.GetCustomAttributes(true).SingleOrDefault(p => p.GetType().Name.Equals("KeyAttribute")) != null)
                        return (int)propertyInfo.GetValue(entity, null);

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Pega o valor pelo nome do atributo informado.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pAttributeName">Pode ser passado o nome completo ou reduzido do atributo.</param>
        /// <returns></returns>
        public static object BuscarValor(object entity, string attributeName)
        {
            try
            {
                PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo propertyInfo in properties)
                    if (propertyInfo.PropertyType.FullName.Equals(attributeName) || propertyInfo.PropertyType.Name.Equals(attributeName))
                        return propertyInfo.GetValue(entity, null);

                return null;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static object Converter(Type typeForConvert, object classFromConvert)
        {
            TypeConverter mConverter = TypeDescriptor.GetConverter(typeForConvert);

            if (mConverter.CanConvertTo(classFromConvert.GetType()))
            {
                return mConverter.ConvertFrom(classFromConvert);
            }

            return null;
        }

    }
}
