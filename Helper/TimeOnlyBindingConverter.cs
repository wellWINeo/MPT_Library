using System;
using ReactiveUI;

namespace Library.Helper;

public class TimeOnlyToTimeSpanBindingConverter : IBindingTypeConverter
{
    /// <summary>
    /// Можно ли конвертировать
    /// </summary>
    /// <param name="fromType">Из какого типа</param>
    /// <param name="toType">В какой тип</param>
    /// <returns>Можно ли конвертировать</returns>
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        return fromType == typeof(TimeOnly) && toType == typeof(TimeSpan?) ? 100 : 0;
    }

    /// <summary>
    /// Метод для конвертации
    /// </summary>
    /// <param name="from">Исходное значение</param>
    /// <param name="toType">Тип, в который надо конвертировать</param>
    /// <param name="conversionHint">Подсказка для конвертации</param>
    /// <param name="result">Результат</param>
    /// <returns>Получилось ли конвертировать</returns>
    public bool TryConvert(object? @from, Type toType, object? conversionHint, out object? result)
    {
        try
        {
            var timeOnly = from as TimeOnly?;
            if (timeOnly != null)
                result = timeOnly.Value.ToTimeSpan();
            else
                result = null;
            return true;
        }
        catch (Exception e)
        {
            result = null;
            return false;
        }
    }
}

public class TimeSpanToTimeOnlyBindingConverter : IBindingTypeConverter
{
    /// <summary>
    /// Можно ли конвертировать
    /// </summary>
    /// <param name="fromType">Из какого типа</param>
    /// <param name="toType">В какой тип</param>
    /// <returns>Можно ли конвертировать</returns>
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        return fromType == typeof(TimeSpan?) && toType == typeof(TimeOnly?) ? 100 : 0;
    }

    /// <summary>
    /// Метод для конвертации
    /// </summary>
    /// <param name="from">Исходное значение</param>
    /// <param name="toType">Тип, в который надо конвертировать</param>
    /// <param name="conversionHint">Подсказка для конвертации</param>
    /// <param name="result">Результат</param>
    /// <returns>Получилось ли конвертировать</returns>
    public bool TryConvert(object? @from, Type toType, object? conversionHint, out object? result)
    {
        try
        {
            var timeSpan = from as TimeSpan?;
            if (timeSpan != null)
                result = TimeOnly.FromTimeSpan((TimeSpan)timeSpan);
            else
                result = null;
            return true;
        }
        catch (Exception e)
        {
            result = null;
            return false;
        }
    }
}