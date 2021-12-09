## About

Простая библиотека написанная на языке C# для построения и генерации запроса к сайту Cian, для последующего парсинга.
С ее помощью легко строить запросы в стиле ООП, а при помощи парсера, получать удобно структурированные данные.

## How to use QueryBuilder

Пример построения запроса, на покупку, 1, 2, 3-комнатных квартир в Москве, отсортированных по цене в порядке увеличения.
```c#
string queryFlat = CianQueryBuilderFactory.ForFlat()
    .SetDealType(DealType.Sale)
    .SetRegion(Region.Moscow)
    .SetRooms(1, 2, 3)
    .SortBy(SortBy.PriceFromSmallToLarge)
    .Page(1)
    .Build();
```
Результат
```
https://www.cian.ru/cat.php?&deal_type=sale&offer_type=flat&engine_version=2&region=1&p=1&sort=price_object_order&room1=1&room2=1&room3=1
```

------------

Возможность генерировать множество Uri исходя из заданного диапазона начальной и конечной страницы.
```c#
IList<string> queryCollection = CianQueryBuilderFactory.ForFlat()
    .SetDealType(DealType.Rent)
    .SetRegion(Region.Spb)
    .SetRooms(2, 3)
    .BuildByPageRange(1, 5);
```
Результат
```
https://www.cian.ru/cat.php?&offer_type=rent&type=4&offer_type=flat&engine_version=2&region=2&p=1&room2=1&room3=1
https://www.cian.ru/cat.php?&offer_type=rent&type=4&offer_type=flat&engine_version=2&region=2&p=2&room2=1&room3=1
https://www.cian.ru/cat.php?&offer_type=rent&type=4&offer_type=flat&engine_version=2&region=2&p=3&room2=1&room3=1
https://www.cian.ru/cat.php?&offer_type=rent&type=4&offer_type=flat&engine_version=2&region=2&p=4&room2=1&room3=1
https://www.cian.ru/cat.php?&offer_type=rent&type=4&offer_type=flat&engine_version=2&region=2&p=5&room2=1&room3=1
```

## How to use HttpCianParser

Парсеру передается Uri (например сгенрированный при помощи QueryBuilder), после обработки запроса будет возвращена коллекция моделей данных. 
```c#
var cianParser = new HttpCianParser(new HttpClient());

var offersOnPage = await cianParser.SetUri(queryFlat).GetOffersOnPage();

foreach (var offer in offersOnPage)
{
    Console.WriteLine($"Id объекта: {offer.Id}");
    Console.WriteLine($"Заголовок: {offer.Title}");
    Console.WriteLine($"Этаж: {offer.FloorNumber}");
    Console.WriteLine($"Общая площадь: {offer.TotalArea}");
}
```
Результат
```
Id объекта: 2642636xx
Заголовок: Студия с Московской пропиской!
Этаж: 3
Общая площадь: 26.0
....
```
## Contacts

Если вам нужна расширенная версия, можете связаться со мной devalexandr@yandex.ru

## License

Данная библиотека с открытым исходным кодом, распространяемая по лицензии [MIT](https://opensource.org/licenses/MIT).