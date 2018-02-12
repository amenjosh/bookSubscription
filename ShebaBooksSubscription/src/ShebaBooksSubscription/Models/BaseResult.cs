using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebReceive.Models
{
    public class BaseResult<T>
    {

        public IList<T> Data { get; set; }
        public DateTime? LastUpdate {get;set;}
        public int RowCount{get;set;}
    }
    public static class ToBaseResult<T>
    {
        public static BaseResult<T> ChangeToBaseResult(List<T> t)
        {
            var result = new BaseResult<T>()
            {
                Data = t
            };
            return result;
        }
         public static BaseResult<T> ChangeToBaseResult(List<T> t,DateTime lastUpdate,int rowCount)
        {
            var result = new BaseResult<T>()
            {
                Data = t,
                LastUpdate = lastUpdate,
                RowCount = rowCount
            };
            return result;
        }
    }
}
