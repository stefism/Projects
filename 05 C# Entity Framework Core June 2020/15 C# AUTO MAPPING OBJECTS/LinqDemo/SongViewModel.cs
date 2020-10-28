using System;

namespace LinqDemo
{
    public  class SongViewModel
    {
        public string Name { get; set; }

        public string SourceName { get; set; }
        // Flattering
        // Във Songs имам Source, а във Source имам Name.
        // Автоматично минава през навигационните пропертита и ако се кръсти така по конвенция, ще вземе пропертито Name от Source. Трябва името да съдържа точно как се казват пропертитата на класовете за да сработи.

        public string Artists { get; set; }

        public DateTime LastModified { get; set; }
    }
}