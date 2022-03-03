using System;
using ReactiveUI;

namespace Library.Helper;

public class TimeOnlyToTimeSpanBindingConverter : IBindingTypeConverter
{
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        return fromType == typeof(TimeOnly) && toType == typeof(TimeSpan?) ? 100 : 0;
    }

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
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        return fromType == typeof(TimeSpan?) && toType == typeof(TimeOnly?) ? 100 : 0;
    }

    public bool TryConvert(object? @from, Type toType, object? conversionHint, out object? result)
    {
        try
        {
            var timeSpan = from as TimeSpan?;
            if (timeSpan != null)
                result = TimeOnly.FromTimeSpan((TimeSpan) timeSpan);
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