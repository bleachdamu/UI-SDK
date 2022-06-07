public interface ISerializeOption 
{
    T DeserializeObject<T>(string text);
}
