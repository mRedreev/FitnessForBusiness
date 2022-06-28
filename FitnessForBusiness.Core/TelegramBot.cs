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

        static List<Training> _NewTrainings = new List<Training>();

        static List<Training> botUpdates = _storage.GetTrainings;

        static string _nameOfNewTraining;
        
        static List<TrainingType> types = functions.MakeTrainingTypes();

        static List<Excercise> excercises = _storage.GetExcercises;
        public static void Main()
        {
            //Read all saved updates

            
            //try
            //{
               
            //    //var botUpdatesString = System.IO.File.ReadAllText(fileName);

            //    //botUpdates = JsonConvert.DeserializeObject<List<Training>>(botUpdatesString) ?? botUpdates;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error reading or deserializing {ex}");
            //}

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

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static string ForDelete()
        {
            string arrOfId = "Выберите Id тренировки, которую хотите удалить: \n";
            foreach (var item in botUpdates)
            {
                arrOfId += item.Id.ToString() + "\n";
            }
            return arrOfId;
        }

        private static string ForAdd(Training _botUpdate)
        {
            string arrOfId = "Выберите id упражнения, которое хотите добавить: \n";
            if (_botUpdate.Type == types[0])
            {
                foreach (var item in functions.cardioExcercises) //CARDIO
                {
                    if (item.Level == _botUpdate.Level)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            else if (_botUpdate.Type == types[3]) //POWER
            {
                foreach (var item in functions.powerExcercises)
                {
                    if (item.Level == _botUpdate.Level)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            else if (_botUpdate.Type == types[1]) //YOGA
            {
                foreach (var item in functions.yogaExcercises)
                {
                    if (item.Level == _botUpdate.Level)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            else
            {
                foreach (var item in functions.warmupExercises) // WARM-UP
                {
                    if (item.Level == _botUpdate.Level)
                    {
                        arrOfId += item.Id.ToString() + " " + item.Name + "\n";
                    }
                }
            }
            return arrOfId;
        }

        private static async Task MessageHandler(ITelegramBotClient bot, Update update, CancellationToken arg3, Training _botUpdate)
        {
            if (update.Message.Type == MessageType.Text)
            {
                var del = new List<string>();
                foreach (var item in botUpdates)
                {
                    del.Add(item.Id.ToString());
                }
                var adds = new List<string>();
                foreach (var item in excercises)
                {
                    if (item.Level == _botUpdate.Level)
                    {
                        adds.Add(item.Id.ToString());
                    }
                }
                Console.WriteLine(JsonConvert.SerializeObject(update));
                if (update.Type == UpdateType.Message)
                {
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
                        //_botUpdate.Id = Guid.NewGuid();

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
                        await bot.SendTextMessageAsync(message.Chat, "Удалено");
                    }
                    if (TypesOfTraining.ToLower().Contains(message.Text.ToLower()))
                    {
                        var training_type = message.Text;
                        if (training_type == "Кардио")
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Type = types[0];
                                }
                            }
                            _botUpdate.Type = types[0];
                        }
                        else if (training_type == "Силовая")
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Type = types[3];
                                }
                            }
                            _botUpdate.Type = types[3];
                        }
                        else if (training_type == "Йога")
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Type = types[1];
                                }
                            }
                            _botUpdate.Type = types[1];
                        }
                        else
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Type = types[2];
                                }
                            }
                            _botUpdate.Type = types[2];
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
                    if (Levels.ToLower().Contains(message.Text.ToLower()))
                    {
                        var level = message.Text;
                        if (level == "Новичок")
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Level = null;
                                }
                            }
                            _botUpdate.Level = null;
                        }
                        else if (level == "Любитель")
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Level = false;
                                }
                            }
                            _botUpdate.Level = false;
                        }
                        else
                        {
                            foreach (var item in botUpdates)
                            {
                                if (item.Id == _botUpdate.Id)
                                {
                                    item.Level = true;
                                }
                            }
                            _botUpdate.Level = true;
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
                        foreach (var item in botUpdates)
                        {
                            if (item.Id == _botUpdate.Id)
                            {
                                item.Name = message.Text;
                            }
                        }
                        _botUpdate.Name = message.Text;
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
                    if (message.Text.ToLower().Contains("добавить упражнение"))
                    {
                        await bot.SendTextMessageAsync(message.Chat, ForAdd(_botUpdate));
                    }
                    if (adds.Contains(message.Text))
                    {
                        foreach (var item in botUpdates)
                        {
                            if (item.Id == _botUpdate.Id)
                            {
                                item.Excercises.Add(excercises.Where(e => e.Id == int.Parse(message.Text)).First());
                                item.ExcerciseAmount = item.Excercises.Count;
                                item.Equipment = new List<Equipment>();
                                var equipmentList1 = item.Excercises.Select(e => e.Equipment.Name).Distinct().ToList();
                                equipmentList1 = equipmentList1.Distinct().ToList();

                                foreach (var equipment in equipmentList1)
                                {
                                    if (!item.Equipment.Any(e => e.Name == equipment))
                                        item.Equipment.Add(new Equipment(equipment));

                                }
                                var bodyparts1 = item.Excercises.Select(e => e.BodyParts.Name).ToList();
                                bodyparts1 = bodyparts1.Distinct().ToList();

                                for (int i = 0; i < bodyparts1.Count; i++)
                                {
                                    if (!item.Description.Contains(bodyparts1[i]))
                                    {
                                        item.Description = item.Description + bodyparts1[i];
                                        item.Description = item.Description + ", ";
                                    }
                                }
                            }
                        }
                        _botUpdate.Excercises.Add(excercises.Where(e => e.Id == int.Parse(message.Text)).First());
                        _botUpdate.ExcerciseAmount = _botUpdate.Excercises.Count;
                        _botUpdate.Equipment = new List<Equipment>();
                        var equipmentList = _botUpdate.Excercises.Select(e => e.Equipment.Name).Distinct().ToList();
                        equipmentList = equipmentList.Distinct().ToList();

                        foreach (var equipment in equipmentList)
                        {
                            if (!_botUpdate.Equipment.Any(e => e.Name == equipment))
                                 _botUpdate.Equipment.Add(new Equipment(equipment));
                        }
                        var bodyparts = _botUpdate.Excercises.Select(e => e.BodyParts.Name).ToList();
                        bodyparts = bodyparts.Distinct().ToList();

                        for (int i = 0; i < bodyparts.Count; i++)
                        {
                            if (!_botUpdate.Description.Contains(bodyparts[i]))
                            {
                                _botUpdate.Description = _botUpdate.Description + bodyparts[i];
                                _botUpdate.Description = _botUpdate.Description + ", ";
                            }
                        }

                        await bot.SendTextMessageAsync(message.Chat, "Добавлено");
                    }
                    if (message.Text.ToLower() == "/end")
                    {
                        await bot.SendTextMessageAsync(message.Chat, "Введите длительность упражнения", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите длительность упражнения"))
                    {
                        foreach (var item in botUpdates)
                        {
                            if (item.Id == _botUpdate.Id)
                            {
                                item.ExcerciseLength = double.Parse(message.Text);
                            }
                        }
                        _botUpdate.ExcerciseLength = double.Parse(message.Text);
                        await bot.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Введите длительность перерыва", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите длительность перерыва"))
                    {
                        foreach (var item in botUpdates)
                        {
                            if (item.Id == _botUpdate.Id)
                            {
                                item.BreakLength = double.Parse(message.Text);
                            }
                        }
                        _botUpdate.BreakLength = double.Parse(message.Text);
                        await bot.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Введите количество кругов", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                    if (message.ReplyToMessage != null && message.ReplyToMessage.Text.Contains("Введите количество кругов"))
                    {
                        foreach (var item in botUpdates)
                        {
                            if (item.Id == _botUpdate.Id)
                            {
                                item.CircleAmount = int.Parse(message.Text);
                                item.Length = (item.ExcerciseLength + item.BreakLength) * item.ExcerciseAmount * item.CircleAmount - item.BreakLength;
                            }
                        }
                        _botUpdate.CircleAmount = int.Parse(message.Text);
                        _botUpdate.Length = (_botUpdate.ExcerciseLength + _botUpdate.BreakLength) * _botUpdate.ExcerciseAmount * _botUpdate.CircleAmount - _botUpdate.BreakLength;
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
            var _botUpdate = new Training();
            if (update.Type == UpdateType.Message)
            { 
                try
                {
                    await MessageHandler(bot, update, arg3, _botUpdate);
                }
                catch (Exception)
                {

                    await bot.SendTextMessageAsync(update.Message.Chat.Id, "Введите данные корректно");
                }

                
            }
            botUpdates.Add(_botUpdate);
            //if (botUpdates.Count > 0)
            //{
            //var real_update = botUpdates.First();
            //for (int i = 0; i < botUpdates.Count; i++)
            //{
            // botUpdates.RemoveAt(i);
            //}
            //botUpdates.Add(real_update);
            //}

            botUpdates = botUpdates.GroupBy(p => p.Id).Select(gr => gr.First()).ToList();
            if (botUpdates.Count > 1)
            {
                botUpdates.RemoveAll(b => b.Name == null);
            }

            var botUpdatesString = JsonConvert.SerializeObject(botUpdates);
            System.IO.File.WriteAllText(fileName, botUpdatesString);
        }
    }
}
