using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ShareYourInterests.Infrastructure.AutoMapper
{
    public static class AutoMapperHelper
    {
        /// <summary>
        /// 类型映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            var config=new MapperConfiguration(cfg=>cfg.CreateMap(obj.GetType(),typeof(T)));
            var mapper = config.CreateMapper();
            return mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合映射
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            if (source == null) return default(List<TDestination>);
            Type sourceType = source.GetType().GetGenericArguments()[0];
            var config = new MapperConfiguration(cfg => cfg.CreateMap(sourceType, typeof(TDestination)));
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }
    }
}
