using System;
using MultiplayerGames_Server.Application.Common.Attributes;

namespace MultiplayerGames_Server.WebApi.Helpers;

public class ObjectUrlWrapper
{
    private readonly FileUrlHelper _fileUrlHelper;

    public ObjectUrlWrapper(FileUrlHelper fileUrlHelper)
    {
        _fileUrlHelper = fileUrlHelper;
    }

    public T WrapObjectUrls<T>(T obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var fileAttribute = Attribute.GetCustomAttribute(property, typeof(FileAttribute));
            if (fileAttribute != null && property.PropertyType == typeof(string))
            {
                var value = property.GetValue(obj) as string;
                var wrappedValue = _fileUrlHelper.WrapPath(value);
                property.SetValue(obj, wrappedValue);
            }
        }

        return obj;
    }
}
