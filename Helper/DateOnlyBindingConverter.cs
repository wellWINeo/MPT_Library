using System;
using System.Globalization;
using ReactiveUI;

namespace Library.Helper;

public class DateOnlyToDateTimeOffsetBindingConverter : IBindingTypeConverter
{
    /// <summary>
    /// Можно ли конвертировать
    /// </summary>
    /// <param name="fromType">Из какого типа</param>
    /// <param name="toType">В какой тип</param>
    /// <returns>Можно ли конвертировать</returns>
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        return fromType == typeof(DateOnly) && toType == typeof(DateTimeOffset) ? 100 : 0;
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
            var dateOnly = (from as DateOnly?);
            result = (DateTimeOffset) dateOnly.Value.ToDateTime(TimeOnly.Parse("00:00"));
            return true;
        }
        catch (Exception e)
        {
            result = null;
            return false;
        }
    }
}

public class DateTimeOffsetToDateOnlyBindingConverter : IBindingTypeConverter
{
    /// <summary>
    /// Можно ли конвертировать
    /// </summary>
    /// <param name="fromType">Из какого типа</param>
    /// <param name="toType">В какой тип</param>
    /// <returns>Можно ли конвертировать</returns>
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        return fromType == typeof(DateTimeOffset) && toType == typeof(DateOnly) ? 100 : 0;
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
            var dateTime = (from as DateTimeOffset?);
            result = DateOnly.FromDateTime(dateTime.Value.Date);
            return true;
        }
        catch (Exception e)
        {
            result = null;
            return false;
        }
    }
}