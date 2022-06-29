using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using FitnessForBusiness.Core.Models;
using System.Threading;
using Update = Telegram.Bot.Types.Update;
using Telegram.Bot.Polling;
using FitnessForBusiness.Core.Storages;
using System.Windows;

namespace FitnessForBusiness.Core
{
    public class TelegramBot
    {
        static TelegramBotClient Bot = new TelegramBotClient("5590195881:AAEnlIe-Yn2cZhjwteSzuuOx9UcPtkqCmQ4");
        private const string FirstOptionText = "Добавить новую тренировку";
        private const string SecondOptionText = "Удалить тренировку";
        private const string TypesOfTraining = "Кардио Силовая Йога Разминка";
        private const string Levels = "Новичок Любитель Продвинутый";

        static string fileName = "../../../FitnessForBusiness.Core/Data/trainings.json";
        static IStorage _storage = new JSONStorage();

        static List<Training> botUpdates = _storage.GetTrainings;

        static string _nameOfNewTraining;
        static TrainingType _typeOfNewTraining;
        static bool? _levelOfNewTraining;
        static List<Excercise> _excercisesOfNewTraining = new List<Excercise>();
        static double _exerciseLengthOfNewTraining;
        static double _breakLengthOfNewTraining;
        static int _circleAmountOfNewTraining;
        static int _step;

        static List<TrainingType> types = functions.MakeTrainingTypes();

        static List<Excercise> excercises = _storage.GetExcercises;

        static List<Excercise> powerExcercises = excercises.Where(e => e.Equipment.Name == "cable" || e.Equipment.Name == "leverage machine").ToList();

        public static void Main()
        {
            try
            {
                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                }
                };

                Bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);


                Console.ReadLine();
            }
            catch (Exception)
            {
                MessageBox.Show("Something in Telegram Bot went wrong");
            }
        }

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static string ForDelete()
        {
            string arrOfId = "Выберите Id тренировки, которую хотите удалить: \n";
            foreach (var item in botUpdates)
            {
                arrOfId += item.Id.ToString() + " " + item.Name + "\n";
            }
            return arrOfId;
        }

        private static string ForAdd()
        {
            string arrOfId = "Выберите id упражнения, которое хотите добавить: \n";
            if (_typeOfNewTraining == types[0])
            {
                foreach (var item in functions.cardioExcercises) //CARDIO
                {
                    if (item.Level == _levelOfNewTraining)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            if (_typeOfNewTraining == types[3]) //POWER
            {
                foreach (var item in powerExcercises)
                {
                    if (item.Level == _levelOfNewTraining)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            if (_typeOfNewTraining == types[1]) //YOGA
            {
                foreach (var item in functions.yogaExcercises)
                {
                    if (item.Level == _levelOfNewTraining)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            if (_typeOfNewTraining == types[2])
            {
                foreach (var item in functions.warmupExercises) // WARM-UP
                {
                    if (item.Level == _levelOfNewTraining)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            return arrOfId;
        }

        private static async Task MessageHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            if (update.Message.Type == MessageType.Text)
            {
                Console.WriteLine(JsonConvert.SerializeObject(update));
                if (update.Type == UpdateType.Message)
                {
                    var del = new List<string>();
                    foreach (var item in botUpdates)
                    {
                        del.Add(item.Id.ToString());
                    }
                    var adds = new List<string>();
                    foreach (var item in excercises)
                    {
                        if (item.Level == _levelOfNewTraining)
                        {
                            adds.Add(item.Id.ToString());
                        }
                    }
                    var message = update.Message;
                    if (message.Text.ToLower() == "/start")
                    {
                        await bot.SendTextMessageAsync(message.Chat, "Добро пожаловать в систему админа!");
                        await bot.SendTextMessageAsync(chatId: message.Chat.Id, text: "Выберите действие",
                            replyMarkup: new ReplyKeyboardMarkup(new[]
                            {
                                    new KeyboardButton(FirstOptionText),
                                    new KeyboardButton(SecondOptionText),
                            })
                            {
                                ResizeKeyboard = true
                            },
                            cancellationToken: arg3);
                    }
                    else if (message.Text.ToLower() == FirstOptionText.ToLower())
                    {
                        await bot.SendTextMessageAsync(message.Chat, "Введите название тренировки:", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }

                    else if (message.Text.ToLower() == SecondOptionText.ToLower())
                    {
                        await bot.SendTextMessageAsync(message.Chat, ForDelete());
                    }
                    if (del.Contains(message.Text))
                    {
                        var id_delete = message.Text;
                        botUpdates.RemoveAll(item => item.Id.ToString() == id_delete);
                        var botUpdatesString = JsonConvert.SerializeObject(botUpdates);
                        System.IO.File.WriteAllText(fileName, botUpdatesString);
                        await bot.SendTextMessageAsync(message.Chat, "Удалено");
                    }
                    if (TypesOfTraining.ToLower().Contains(message.Text.ToLower()) && _step == 1)
                    {
                        _step = 2;
                        var training_type = message.Text;
                        if (training_type == "Кардио")
                        {
                            _typeOfNewTraining = types[0];
                        }
                        else if (training_type == "Силовая")
                        {
                            _typeOfNewTraining = types[3];
                        }
                        else if (training_type == "Йога")
                        {
                            _typeOfNewTraining = types[1];
                        }
                        else
                        {
                            _typeOfNewTraining = types[2];
                        }
                        await bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Введите уровень тренировки:",
                        replyMarkup: new ReplyKeyboardMarkup(new[]
                            {
                                    new KeyboardButton("Новичок"),
                                    new KeyboardButton("Любитель"),
                                    new KeyboardButton("Продвинутый"),
                            })
                        {
                            ResizeKeyboard = true
                        },
                        cancellationToken: arg3);
                    }
                    if (Levels.ToLower().Contains(message.Text.ToLower()) && _step == 2)
                    {
                        _step = 3;
                        var level = message.Text;
                        if (level == "Новичок")
                        {
                            _levelOfNewTraining = null;
                        }
                        else if (level == "Любитель")
                        {
                            _levelOfNewTraining = false;
                        }
                        else
                        {
                            _levelOfNewTraining = true;
                        }
                        await bot.SendTextMessageAsync(message.Chat, "Теперь добавьте упражнения в тренировку (напишите /end, когда закончите)", replyMarkup: new ReplyKeyboardMarkup(new[]
                            {
                                    new KeyboardButton("Добавить упражнение"),
                            })
                        {
                            ResizeKeyboard = true
                        },
                            cancellationToken: arg3);
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите название тренировки:"))
                    {
                        _step = 1;
                        _nameOfNewTraining = message.Text;
                        await bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Выберите тип тренировки:",
                        replyMarkup: new ReplyKeyboardMarkup(new[]
                        {
                            new []
                            {
                                new KeyboardButton("Кардио"),
                                new KeyboardButton("Силовая"),
                            },
                            new []
                            {
                                new KeyboardButton("Йога"),
                                new KeyboardButton("Разминка"),
                            },
                        })
                        {
                            ResizeKeyboard = true
                        },
                        cancellationToken: arg3);
                    }
                    if (message.Text.ToLower().Contains("добавить упражнение") && _step == 3)
                    {
                        _step = 4;
                        await bot.SendTextMessageAsync(message.Chat, ForAdd());
                    }
                    if (adds.Contains(message.Text) && _step == 4)
                    {
                        _step = 3;
                        _excercisesOfNewTraining.Add(excercises.Where(e => e.Id == int.Parse(message.Text)).First());
                        await bot.SendTextMessageAsync(message.Chat, "Добавлено");
                    }
                    if (message.Text.ToLower() == "/end")
                    {
                        _step = 5;
                        await bot.SendTextMessageAsync(message.Chat, "Введите длительность упражнения", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите длительность упражнения") && _step == 5)
                    {
                        _step = 6;
                        _exerciseLengthOfNewTraining = double.Parse(message.Text);
                        await bot.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Введите длительность перерыва", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите длительность перерыва") && _step == 6)
                    {
                        _step = 7;
                        _breakLengthOfNewTraining = double.Parse(message.Text);
                        await bot.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Введите количество кругов", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите количество кругов") && _step == 7)
                    {
                        _step = 8;
                        _circleAmountOfNewTraining = int.Parse(message.Text);
                        await bot.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Теперь все! Новая тренировка добавлена",
                            replyMarkup: new ReplyKeyboardMarkup(new[]
                            {
                                    new KeyboardButton(FirstOptionText),
                                    new KeyboardButton(SecondOptionText),
                            })
                            {
                                ResizeKeyboard = true
                            },
                            cancellationToken: arg3);

                    }
                }
            }
        }

        private static async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            if (update.Type == UpdateType.Message)
            {
                try
                {
                    await MessageHandler(bot, update, arg3);
                }
                catch (Exception)
                {

                    await bot.SendTextMessageAsync(update.Message.Chat.Id, "Введите данные корректно");
                }


            }
            if (_step == 8)
            {
                var _botUpdate = new Training(_nameOfNewTraining, _typeOfNewTraining, _levelOfNewTraining, _excercisesOfNewTraining, _exerciseLengthOfNewTraining, _breakLengthOfNewTraining, _circleAmountOfNewTraining);
                botUpdates.Add(_botUpdate);
                var botUpdatesString = JsonConvert.SerializeObject(botUpdates);
                System.IO.File.WriteAllText(fileName, botUpdatesString);
                _step = 0;
                _excercisesOfNewTraining.Clear();
            }
        }
    }
}