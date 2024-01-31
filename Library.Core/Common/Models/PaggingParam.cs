﻿namespace Library.Core.Common.Models
{
    public class PaggingParam
    {
        const int maxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
