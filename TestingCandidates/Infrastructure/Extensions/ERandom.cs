using System;

namespace Testing.Infrastructure.Extensions
{
    public static class ERandom
    {
        /// <summary>
        /// Сгенерировать дробное число в диапазоне с шагом
        /// </summary>
        /// <param name="random"></param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="step">Шаг</param>
        /// <returns></returns>
        public static double NextDoubleInRangeWithStep(this Random random, double min, double max, double step)
        {
            int possibleValuesCount = (int)((max - min) / step) + 1;

            int randomIndex = random.Next(possibleValuesCount);

            double result = min + randomIndex * step;

            return result;
        }
    }
}
