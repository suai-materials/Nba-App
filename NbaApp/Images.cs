using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NbaApp;

public class Images : ViewModel
{
    // Путь до картинок
    private const string PATH = @"C:\Users\user\Desktop\NbaApp\NbaApp\res\";
    private string[] _showedImages;

    private int _index = 0;

    // Получаем все картинки из подпапок, а также их фильтруем по *.jpg
    private List<string> _images = Directory.EnumerateFiles(PATH, "*.jpg", SearchOption.AllDirectories).ToList();

    // Параметры для binding
    public string Img1
    {
        get => _showedImages[0];
        set => _showedImages[0] = value;
    }

    public string Img2
    {
        get => _showedImages[1];
        set => _showedImages[1] = value;
    }

    public string Img3
    {
        get => _showedImages[2];
        set => _showedImages[2] = value;
    }

    public Images()
    {
        ShowImages();
    }

    // Функция отображения картинок по индексу
    private void ShowImages()
    {
        if (_images.Count == 0)
            return;

        // Если у нас одна картинка просто зацикливаем одну картинку  и наплевать на индексы
        if (_images.Count == 1)
            _showedImages = new[] {_images[0], _images[0], _images[0]};
        else if (_index + 3 >= _images.Count)
        {
            var list_ = _images.GetRange(_index, _images.Count - _index);
            list_.AddRange(_images.GetRange(0, 3 - (_images.Count - _index)));
            _showedImages = list_.ToArray();
        }
        else
        {
            _showedImages = _images.GetRange(_index, 3).ToArray();
        }

        // Уведомление WPF о измененения в этих Properties
        NotifyPropertyChanged("Img1");
        NotifyPropertyChanged("Img2");
        NotifyPropertyChanged("Img3");
    }

    // Высчитываем новый индекс при листании вправо и меняем картинки
    public void Right()
    {
        if (_images.Count == 0)
            return;

        // Если индекс превышает допустимое значение, получаем новый цикличный индекс, иначе просто листаем на 3
        if (_index + 3 >= _images.Count)
            _index = 3 - (_images.Count - _index);
        else
            _index += 3;
        /* Cуществует ошибка если индекс меньше 3, то мы не получаем новый корректно(вычитание из тройки),
         это исправляет ошибку*/
        if (_images.Count < 3 && _index == _images.Count)
            _index = 0;
        ShowImages();
    }

    // Высчитываем новый индекс при листании влево и меняем картинки
    public void Left()
    {
        if (_images.Count == 0)
            return;
        if (_index - 3 <= 0)
            _index = Math.Abs(_images.Count + (_index - 3));
        else
            _index -= 3;
        ShowImages();
    }
}