using System;

namespace XmasChecker
{
    public class XmasChecker
    {
        private DateTime _dateTime;

        public XmasChecker()
        {
            _dateTime = DateTime.Today;
        }

        public XmasChecker(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public bool IsTodayXmas()
        {
            var today = _dateTime;
            if (today.Month == 12 && today.Day == 25)
            {
                return true;
            }
            return false;
        }
    }
}