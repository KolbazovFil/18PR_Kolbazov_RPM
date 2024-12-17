using System;
using System.Windows;
using System.Windows.Threading;
namespace _18PR_Kolbazov_RPM
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime startTime;
        private TimeSpan elapsedTime; // Переменная для хранения времени
        private bool isPaused = false; // Флаг для проверки состояния таймера
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();  // Инициализация таймера
            timer.Interval = TimeSpan.FromMilliseconds(1); // Установка интервала в 1 миллисекунду
            timer.Tick += Timer_Tick; // Подписка на событие Tick
        }
        private void Timer_Tick(object sender, EventArgs e) // Обработчик события Tick
        {
            if (!isPaused) // Если таймер не на паузе
            {
                elapsedTime = DateTime.Now - startTime; // Вычисляем прошедшее время
            }
            TimerTextBlock.Text = $"{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}:{elapsedTime.Milliseconds / 10:D2}"; // Обновляем текст на экране
        }
        private void StartTimerButton_Click(object sender, RoutedEventArgs e)   // Обработчик для кнопки Старт
        {
            if (isPaused) // Если таймер на паузе
            {
                startTime = DateTime.Now - elapsedTime; // Изменяем начало так, чтобы учитывать уже прошедшее время
                isPaused = false; // Снимаем паузу
            }
            else
            {
                elapsedTime = TimeSpan.Zero; // Сбрасываем время при новом старте
                startTime = DateTime.Now; // Запоминаем время старта
            }
            timer.Start(); // Запускаем таймер
        }
        private void PauseTimerButton_Click(object sender, RoutedEventArgs e)    // Обработчик для кнопки Пауза
        {
            timer.Stop(); // Останавливаем таймер
            isPaused = true; // Устанавливаем флаг паузы
        }
        private void StopTimerButton_Click(object sender, RoutedEventArgs e)    // Обработчик для кнопки Стоп
        {
            timer.Stop(); // Останавливаем таймер
            isPaused = false; // Сброс флага паузы

            elapsedTime = TimeSpan.Zero; // Сбрасываем время

            TimerTextBlock.Text = "00:00:00"; // Сбрасываем текстовый блок
        }
    }
}