Принцип единственной ответственности: вместо того чтобы объединять функционал настроек, игры и рандомайзера в один класс, разделили на разные сущности в зависимости от задач;

Принцип инверсии зависимостей: класс игры зависит от интерфейса IRandomizer, а не от конкретной реализации;

Принцип разделения интерфейса: представим, что есть какой-то статический рандомайзер (на этапе написания кода ставим диапазон) и динамический рандомайзер (определяем диапазон с клавиатуры). Метод установки диапазона разносим по разным интерфейсам;

Принцип открытости/закрытости: если появится новый способ рандома числа мы не будем менять существующие реализации, а напишем нового наследника от IRandomizer;

Принцип подстановки Барбары Лисков: при подстановке вместо IRandomizer конкретных реализаций DynamicRandomizer, StaticRandomizer получаем на выходе все то же одно число и работа программы не ломается;
На выполнение задачи ушло в сумме около 6 часов
