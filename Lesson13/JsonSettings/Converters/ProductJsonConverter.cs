using Lesson13.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lesson13.JsonSettings.Converters;

public class ProductJsonConverter : JsonConverter<Product>
{
    public override Product? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var modelTypeReader = reader;

        if (modelTypeReader.TokenType != JsonTokenType.StartObject) {
            throw new JsonException();
        }

        ProductType? productType = null;
        while (modelTypeReader.Read()) {
            if (modelTypeReader.TokenType == JsonTokenType.PropertyName) {
                var propertyName = modelTypeReader.GetString();
                if (propertyName?.ToLower() == "producttype") {
                    modelTypeReader.Read();
                    var modelType = modelTypeReader.GetString();
                    if (!string.IsNullOrWhiteSpace(modelType)) {
                        Enum.TryParse(modelType!, true, out ProductType parsedType);
                        productType = parsedType;
                    }
                    break;
                }
            }
        }

        Product? product = productType switch {
            ProductType.Accessories => JsonSerializer.Deserialize<Accessories?>(ref reader, options),
            ProductType.Book => JsonSerializer.Deserialize<Book?>(ref reader, options),
            ProductType.Food => JsonSerializer.Deserialize<Food?>(ref reader, options),
            _ => throw new JsonException($"Can't find model discriminator {productType}")
        };

        if (product == null) {
            throw new JsonException($"Parsing exception {productType}");
        }

        return product;
    }

    public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options) {
        switch (value) {
            case Accessories accessories:
                JsonSerializer.Serialize(writer, accessories, options);
                break;
            case Book book:
                JsonSerializer.Serialize(writer, book, options);
                break;
            case Food food:
                JsonSerializer.Serialize(writer, food, options);
                break;
        }
    }
}
