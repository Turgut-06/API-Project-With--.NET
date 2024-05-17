using AutoMapper;
using AutoMapper.Internal;
using HepsiApi.Application.Interfaces.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMapper = AutoMapper.IMapper;

namespace HepsiApi.Mapper.AutoMapper
{

    //her seferinde profile yazmak yerine AutoMapper ı generic hale getiriyoruz
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        //direk AutoMapper kütüphanesini kullanıyor bizim yazdığımızı değil
        public static List<TypePair> typePairs = new();
        private IMapper MapperContainer;
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<TSource, TDestination>(source);
        }

       

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {

            Config<TDestination,object>(5, ignore);

            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {

            Config<TDestination, IList<object>>(5, ignore);

            return MapperContainer.Map<IList<TDestination>>(source);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null) //depth; iç içe en fazla 5 tane dto ya kadar mapleme yapabilir demek
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination)); //typePair bunları string olarak almamı işlememi sağlıyor

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
                return; //herhangi bir sıkıntı yoksa devam edip aşağıda kendine ekliyor

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();

                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap(); //birbirlerine dönüşebiliyorlar


                }
            });

            MapperContainer = config.CreateMapper();
        }


    }

       
    }


