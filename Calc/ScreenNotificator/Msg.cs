namespace Calc.ScreenNotificator
{
    // класс для хранения сообщений
    public static class Msg
    {
        public static string invalidinput() => "неверный ввод";
        public static string enternum() => ">";
        public static string enterop() => "@:";
        public static string opnotset() => "операция не задана";
        public static string opbeforenum() => "нельзя вводить операцию перед операндом";
    }
}
