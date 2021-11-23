## About

------------
Простая библиотека написанная на языке C# для построения и генерации запроса к сайту Cian, для последующего парсинга.
С ее помощью легко строить запросы в стиле ООП, а при помощи парсера, получать удобно структурированные данные.

## How to use QueryBuilder

------------
Пример построения запроса, на покупку, 1, 2, 3-комнатной квартиры в Москве, отсортированных по цене в порядке увеличения.
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
Возможность генерировать множество Uri исходя из заданного диапазона начальной и конечной страницы.
```c#
string queryColleciton = CianQueryBuilderFactory.ForFlat()
    .SetDealType(DealType.Rent)
    .SetRegion(Region.Spb)
    .SetRooms(2, 3)
    .BuildByPageRange(1, 5);
```
Результат
```
https://www.cian.ru/cat.php?deal_type=sale&offer_type=suburban&engine_version=2&region=1&p=1&sort=creation_date_desc&object_type%5B0%5D=1&object_type%5B1%5D=4&object_type%5B2%5D=3
https://www.cian.ru/cat.php?deal_type=sale&offer_type=suburban&engine_version=2&region=1&p=2&sort=creation_date_desc&object_type%5B0%5D=1&object_type%5B1%5D=4&object_type%5B2%5D=3
https://www.cian.ru/cat.php?deal_type=sale&offer_type=suburban&engine_version=2&region=1&p=3&sort=creation_date_desc&object_type%5B0%5D=1&object_type%5B1%5D=4&object_type%5B2%5D=3
https://www.cian.ru/cat.php?deal_type=sale&offer_type=suburban&engine_version=2&region=1&p=4&sort=creation_date_desc&object_type%5B0%5D=1&object_type%5B1%5D=4&object_type%5B2%5D=3
https://www.cian.ru/cat.php?deal_type=sale&offer_type=suburban&engine_version=2&region=1&p=5&sort=creation_date_desc&object_type%5B0%5D=1&object_type%5B1%5D=4&object_type%5B2%5D=3
```

## How to use HttpCianParser

------------ 
Парсеру передается Uri (например сгенрированный при помощи QueryBuilder), после обработки запроса будет возвращена коллекция моделей данных. 
```c#
var cianParser = new HttpCianParser(new HttpClient());

var offersOnPage = await cianParser.SetUri(queryFlat).GetOffersOnPage();
```

## License

------------

Данная библиотека с открытым исходным кодом, распространяемое по лицензии [MIT](https://opensource.org/licenses/MIT).