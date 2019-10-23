using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System;

public enum Employee { Seller, KithenGerl, Granny }

static class DialogData
{
    public static DialogSet[] Get(Employee employee)
    {
        switch (employee)
        {
            case Employee.Seller: return DialogData.Seller(); 
            case Employee.KithenGerl: return DialogData.KitchenGirl();
            case Employee.Granny: return DialogData.Granny();
            default: Debug.Log("Для данной професии не установлен лист диалогов. Лол бл."); return null;
        }
    }

    public static DialogSet[] Seller()
    {
        return new DialogSet[] { SellerD1.GetSet(), SellerD2.GetSet(), SellerD3.GetSet() };
    }
    public static DialogSet[] KitchenGirl()
    {
        return new DialogSet[] { KitchenGirlD1.GetSet(), KitchenGirlD2.GetSet(), KitchenGirlD3.GetSet() };
    }
    public static DialogSet[] Granny()
    {
        return new DialogSet[] { OldManD1.GetSet() };
    }
};

class SellerD1
{
    static Dialog dialogA = new Dialog
    {
        dialog = new Question[]
        {
                new Question
                {
                    question = "Хееей, налетай, шелка и вина для дам, лучшие сабли восточных воинов с идеальным балансом, порубят ваших врагов одним видом",
                    answers = new string[] { "Добрый день, могу ли я найти у вас Кумарин?" },
                    pointsForQuestion = new int[] {0},
                    qustionNumber = new int[] { 1 }
                },
                new Question
                {
                    question = "Зачем эта трава вам господин? Лучше попробуйте это вкуснейшее и ароматное вино с лучших виноградников.",
                    answers = new string[] {
                        "Я доктор, разве по мне не видно?! Надо пополнить свои запасы.",
                        "Не твое дело! Есть или нет?",
                        "Для личных целей"
                    },
                    pointsForQuestion = new int[] {1, 0, 0},
                    qustionNumber = new int[] { 2, 2, 2 }
                },
                 new Question
                {
                    question = "К сожалению, данного экземпляра я не имею, возможно появится.",
                    answers = new string[] {
                        "Как жаль. Хорошей торговли, навещу вас позже",
                        "Отвратительно, прощайте"
                    },
                    pointsForQuestion = new int[] {1, 0},
                    qustionNumber = new int[] { -1, -1}
                }
        }
    };
    static Dialog dialogB = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "- Людии, я привез вам лучшие товары со всего мира для вас",
                answers = new string[] {
                    "Здравствуйте, вы не забыли мою просьбу?"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 1}
            },
             new Question
            {
                question = "Опять вы?! Нет, я помню, но у меня есть дела по важнее",
                answers = new string[] {
                    "Что может быть важнее жизни и здоровья больных?",
                    "Что может быть важнее моей просьбы?"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 2, 3}
             },
             new Question
            {
                question = "Спросите у Кухарки, возможно у нее вы сможете найти то что вам нужно ",
                answers = new string[] {
                    "Благодарю"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
             },
             new Question
            {
                question = "Вали отсюда, не пугай людей",
                answers = new string[] {
                    "Уйти"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
             }
        }
    };
    static Dialog dialogC = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Подходи покупай, у меня ты найдешь все, что твоей душе угодно",
                answers = new string[] {
                    "Далее"

                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 1 }
            },
             new Question
            {
                question = "Я не ясно выразился?! Вали!",
                answers = new string[] {
                    "Я бы хотел, извиниться за свое прежнее поведение",
                    "Просто мимо проходил"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] {2, 3 }
            },
             new Question
            {
                question = "Спросите у Кухарки, возможно у нее вы сможете найти то что вам нужно",
                answers = new string[] {
                    "Благодарю"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1}
            },
             new Question
            {
                question = "Вот и проходи",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            }


        }


    };

    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialogA,
                dialogB,
                dialogC
            }
        };
        return dialogSet;
    }
}
class SellerD2
{

    static Dialog dialogA = new Dialog
    {
        dialog = new Question[]
        {
            new Question
            {
                question = "Доктор, приветствую вас!",
                answers = new string[] {
                    "Здравствуйте, как ваши дела?",
                    "У меня нет времени на любезности!"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 1, 2 }
            },
            new Question
            {
                question = "Если бы не старый ворчливый Кузнец, то было бы отлично...",
                answers = new string[] {
                    "далее"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 2}
            },
            new Question
            {
                question = "Могу предложить вам отличное вино десятилетний выдержки.",
                answers = new string[] {
                    "С удовольствием попробую",
                    "Не суйте мне ваше пойло"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 3, -1}


            },
             new Question
            {
                question = "Мне пора возвращаться к работе, заходите еще.",
                answers = new string[] {
                    "До свидания"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            },


        }
    };
    static Dialog dialogB = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Вижу, вы снова решили меня почтить своим присутствием, Бернард",
                answers = new string[] {
                    "Хотел поинтересоваться о вашем здоровье",
                    "Вам показалось, у меня есть дела поважнее"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 1, 2}
            },
            new Question
            {
                question = "Благодарю, мое здоровье в порядке, но вот моя милая дочурка жалуется на то, " +
                "что ей виделся в окне огромный злобный пес. " +
                "Ей богу, что я вас беспокою детскими фантазиями.",
                answers = new string[] {
                    "Хм, интересно, но мне уже пора"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            },
            new Question
            {
                question = "...",
                answers = new string[] {
                    "Выход"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] {-1}
            }
        }


    };
    static Dialog dialogC = new Dialog
    {
        dialog = new Question[] {

             new Question
            {
                question = "У вас что-то серьезное, если нет я пойду заниматься своими делами",
                answers = new string[] {
                    "Я бы хотел, извиниться за свое прежнее поведение",
                    "Просто мимо проходил(Выход)"
                },
                pointsForQuestion = new int[] { 1, 0 },
                qustionNumber = new int[] { 1, 2 }
            },

             new Question
            {
                question = "Рад, что вы одумались",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] { 0 },
                qustionNumber = new int[] { 3 }
            },
              new Question
            {
                question = " Вот и проходи",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] { 0 },
                qustionNumber = new int[] { -1 }
            },

        }


    };

    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialogA,
                dialogB,
                dialogC
            }
        };
        return dialogSet;
    }
};
class SellerD3
{

    static Dialog dialogA = new Dialog
    {
        dialog = new Question[]
    {

            new Question
            {
                question = "Ооо, Бернард, дорогой друг, рад вас видеть!",
                answers = new string[] {
                    "И я вас, что нового расскажите? ",
                    "У меня нет времени на любезности! "

                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 1, -1}
            },
             new Question
            {
                question = "Видимо в этом городе мне никто не рад...Но не будем о грустном",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 2}
            },
             new Question
            {
                question = "Есть у меня для вас интересный подарок. Держите, сам не пробовал, но говорят оно открывает врата в другие миры. Только тс..",
                answers = new string[] {
                    "Как-нибудь попробую на пациентах ",
                    "Нет, мне это не интересно "
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 3, -1}
            },
             new Question
            {
                question = "Мне пора возвращаться к работе, заходите еще.",
                answers = new string[] {
                    "Благодарю за подарок, досвидание"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] {-1}
            }


        }
    };
    static Dialog dialogB = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Доктор, чем могу быть полезен",
                answers = new string[] {
                    "Откуда у вас этот огромный зуб на шее?",
                    "Ничем, уже ухожу"
                },
                pointsForQuestion = new int[] {1 },
                qustionNumber = new int[] { 1, -1}
            },
             new Question
            {
                question = "Обменял у старушки на горшок, клялась, что он принадлежит некому местному монстру, " +
                 "совсем выжила из ума под старость лет…",
                answers = new string[] {
                    "Хм, интересно"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
             }
        }
    };
    static Dialog dialogC = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "У вас что-то серьезное? Если нет, то я пойду заниматься своими делами",
                answers = new string[] {
                    "Я бы хотел, извиниться за свою бестактность в последнее время",
                    "Просто мимо проходил"

                },
                pointsForQuestion = new int[] {1,0},
                qustionNumber = new int[] { 1, -1 }
            },
            new Question
            {
                question = "Боже, друг мой, все хорошо",
                answers = new string[] {
                    "Я рад, что вы не в обиде",

                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            }
        }
    };

    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialogA,
                dialogB,
                dialogC
            }
        };
        return dialogSet;
    }
};


class KitchenGirlD1
{
    static Dialog dialog1 = new Dialog
    {
        dialog = new Question[]
        {
                new Question
                {
                    question = "Горячие пирожки, сладкие, медовые, с рыбой, с мясом, с зеленым луком! Не робей, налетай!",
                    answers = new string[] { "Доброго здравия! Я хотел бы пополнить запасы бочонком испанского рома"},
                    pointsForQuestion = new int[] {0},
                    qustionNumber = new int[] { 1 }
                },
                new Question
                {
                    question = "Хозяин таверны запрещает продавать ром в бочонках. Могу вам предложить кружку превосходного темного пива.",
                    answers = new string[] {
                        "Я - доктор, ром нужен для моих больных, позови хозяина!",
                        "Это возмутительно! Я донесу об этом Графу Людвигу Баварскому!!  Где твой хозяин?"
                    },
                    pointsForQuestion = new int[] {1, 0},
                    qustionNumber = new int[] { 2, 2 }
                },
                 new Question
                {
                    question = " Я сожалею, хозяин сейчас у епископа Петра. Я передам ему о вашем визите",
                    answers = new string[] {
                        "Как жаль.Я навещу вас позже",
                        "Отвратительно, он еще пожалеет об этом!!"
                    },
                    pointsForQuestion = new int[] {1, 0},
                    qustionNumber = new int[] { -1, -1}
                }
        }
    };
    static Dialog dialog2 = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Горячая похлебка, пирожки, блины!! Что вам угодно, Доктор?",
                answers = new string[] {
                    "Доброго дня, вы рассказали обо мне хозяину?"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 1}
            },
             new Question
            {
                question = "Я передала ему о вас. Но он не пожелал с вами видеться",
                answers = new string[] {
                    "От этого зависит жизнь моих больных!",
                    "Он еще поплатиться за нанесенное оскобление!"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 2, 3}
             },
             new Question
            {
                question = "Доктор, я ничем не могу вам помочь. Возможно, вам следует спросить у Торговца",
                answers = new string[] {
                    "Хоть на этом спасибо"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
             },
             new Question
            {
                question = "Идите к торговцу, не мешайте работать!",
                answers = new string[] {
                    "Уйти"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
             }
        }
    };
    static Dialog dialog3 = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Опять вы, Доктор?! Хозяин таверны не желает вас видеть здесь!",
                answers = new string[] {
                    "Далее"

                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 1 }
            },
             new Question
            {
                question = "Не испытывайте мое терпение! Вон!",
                answers = new string[] {
                    "Я бы хотел, извиниться за свое прежнее поведение",
                    "Просто мимо проходил"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] {2, 3 }
            },
             new Question
            {
                question = "Идите к Тоговцу. Возможно, он может вам помочь.",
                answers = new string[] {
                    "Благодарю"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1}
            },
             new Question
            {
                question = "Ну и иди отсюда!",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            }


        }


    };

    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialog1,
                dialog2,
                dialog3
            }
        };
        return dialogSet;
    }
}
class KitchenGirlD2
{

    static Dialog dialog1 = new Dialog
    {
        dialog = new Question[]
        {
            new Question
            {
                question = "Доктор, приветствую вас!",
                answers = new string[] {
                    "Здравствуйте, как ваши дела?",
                    "У меня нет времени на любезности!"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 1, 2 }
            },
            new Question
            {
                question = "Если бы не старый ворчливый Торгаш, то было бы отлично...",
                answers = new string[] {
                    "далее"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 2}
            },
            new Question
            {
                question = "Могу предложить вам отличное вино десятилетний выдержки.",
                answers = new string[] {
                    "С удовольствием попробую",
                    "Не суйте мне ваше пойло"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 3, -1}


            },
             new Question
            {
                question = "Мне пора возвращаться к работе, заходите еще.",
                answers = new string[] {
                    "До свидания"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            },


        }
    };
    static Dialog dialog2 = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Вижу, вы снова решили меня почтить своим присутствием, Бернард",
                answers = new string[] {
                    "Хотел поинтересоваться о вашем здоровье",
                    "Вам показалось, у меня есть дела поважнее"
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 1, 2}
            },
            new Question
            {
                question = "Благодарю, мое здоровье в порядке, но вот моя милая дочурка жалуется на то, " +
                "что ей виделся в окне огромный злобный пес. " +
                "Ей богу, что я вас беспокою детскими фантазиями.",
                answers = new string[] {
                    "Хм, интересно, но мне уже пора"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            },
            new Question
            {
                question = "...",
                answers = new string[] {
                    "Выход"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] {-1}
            }
        }


    };
    static Dialog dialog3 = new Dialog
    {
        dialog = new Question[] {

             new Question
            {
                question = "У вас что-то серьезное, если нет я пойду заниматься своими делами",
                answers = new string[] {
                    "Я бы хотел, извиниться за свое прежнее поведение",
                    "Просто мимо проходил(Выход)"
                },
                pointsForQuestion = new int[] { 1, 0 },
                qustionNumber = new int[] { 1, 2 }
            },

             new Question
            {
                question = "Рад, что вы одумались",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] { 0 },
                qustionNumber = new int[] { 3 }
            },
              new Question
            {
                question = " Вот и проходи",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] { 0 },
                qustionNumber = new int[] { -1 }
            },

        }


    };

    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialog1,
                dialog2,
                dialog3
            }
        };
        return dialogSet;
    }
};
class KitchenGirlD3
{

    static Dialog dialog1 = new Dialog
    {
        dialog = new Question[]
    {

            new Question
            {
                question = "Ооо, Бернард, дорогой друг, рад вас видеть!",
                answers = new string[] {
                    "И я вас, что нового расскажите? ",
                    "У меня нет времени на любезности! "

                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 1, -1}
            },
             new Question
            {
                question = "Видимо в этом городе мне никто не рад...Но не будем о грустном",
                answers = new string[] {
                    "Далее"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { 2}
            },
             new Question
            {
                question = "Есть у меня для вас интересный подарок. Держите, сам не пробовал, но говорят оно открывает врата в другие миры. Только тс..",
                answers = new string[] {
                    "Как-нибудь попробую на пациентах ",
                    "Нет, мне это не интересно "
                },
                pointsForQuestion = new int[] {1, 0},
                qustionNumber = new int[] { 3, -1}
            },
             new Question
            {
                question = "Мне пора возвращаться к работе, заходите еще.",
                answers = new string[] {
                    "Благодарю за подарок, досвидание"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] {-1}
            }


        }
    };
    static Dialog dialog2 = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "Доктор, чем могу быть полезен",
                answers = new string[] {
                    "Откуда у вас этот огромный зуб на шее?",
                    "Ничем, уже ухожу"
                },
                pointsForQuestion = new int[] {1 },
                qustionNumber = new int[] { 1, -1}
            },
             new Question
            {
                question = "Обменял у старушки на горшок, клялась, что он принадлежит некому местному монстру, " +
                 "совсем выжила из ума под старость лет…",
                answers = new string[] {
                    "Хм, интересно"
                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
             }
        }
    };
    static Dialog dialog3 = new Dialog
    {
        dialog = new Question[] {
            new Question
            {
                question = "У вас что-то серьезное? Если нет, то я пойду заниматься своими делами",
                answers = new string[] {
                    "Я бы хотел, извиниться за свою бестактность в последнее время",
                    "Просто мимо проходил"

                },
                pointsForQuestion = new int[] {1,0},
                qustionNumber = new int[] { 1, -1 }
            },
            new Question
            {
                question = "Боже, друг мой, все хорошо",
                answers = new string[] {
                    "Я рад, что вы не в обиде",

                },
                pointsForQuestion = new int[] {0},
                qustionNumber = new int[] { -1 }
            }
        }
    };

    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialog1,
                dialog2,
                dialog3
            }
        };
        return dialogSet;
    }
};

class OldManD1
{
    static Dialog dialog1 = new Dialog
    {
        dialog = new Question[]
        {
                new Question
                {
                    question = "C возвращение в этот мир, сынок!",
                    answers = new string[] { "Вы кто? Где я?" },
                    pointsForQuestion = new int[] {1},
                    qustionNumber = new int[] { 1 }
                },
                new Question
                {
                    question = "Старик я местный, а вот кто ты?",
                    answers = new string[] {
                        "Моё имя Бернард, странствующий лекарь. Как я тут оказался?"

                    },
                    pointsForQuestion = new int[] {1},
                    qustionNumber = new int[] { 2 }
                },
                 new Question
                {
                    question = "хм..Как страно... Я нашел вас раздетым в лесу, видимо вас ограбили.",
                    answers = new string[] {
                        "Что в этом странного?"
                    },
                    pointsForQuestion = new int[] {0},
                    qustionNumber = new int[] {3}
                },
                 new Question
                {
                    question = "У нас пропал местный лекарь, можно сказать, что твое появление очень кстати." +
                     "Было бы не плохо если бы ты задержался на время. Можешь занять его дом, до его появления",
                    answers = new string[] {
                        "Видимо придется"
                    },
                    pointsForQuestion = new int[] {0},
                    qustionNumber = new int[] {-1}
                }
        }
    };


    public static DialogSet GetSet()
    {
        DialogSet dialogSet = new DialogSet
        {
            CountBallsForNextLevel = 2,
            DialogSets = new Dialog[] {
                dialog1
            }
        };
        return dialogSet;
    }
}
