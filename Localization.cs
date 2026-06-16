using System;
using System.Collections.Generic;

namespace RadLab
{
    /// <summary>
    /// Localization system supporting Russian (ru) and English (en) languages.
    /// Stores translations as key-value pairs where key = control Name, value = translated text.
    /// </summary>
    public static class Localization
    {
        public const string LANG_RU = "ru";
        public const string LANG_EN = "en";

        private static string _currentLanguage = LANG_RU;

        /// <summary>
        /// Current active language code ("ru" or "en").
        /// </summary>
        public static string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (value == LANG_RU || value == LANG_EN)
                    _currentLanguage = value;
            }
        }

        /// <summary>
        /// Returns the display text for the language toggle button.
        /// Shows the opposite language (the one you can switch to).
        /// </summary>
        public static string LanguageButtonText => _currentLanguage == LANG_RU ? "En" : "Ру";

        // Dictionary: control Name -> translated text
        private static readonly Dictionary<string, Dictionary<string, string>> Translations = new()
        {
            // ============================================================
            // FormMain controls
            // ============================================================
            ["groupBox1"] = new()
            {
                [LANG_RU] = "График скорости счёта",
                [LANG_EN] = "Count rate graph"
            },
            ["groupBox2"] = new()
            {
                [LANG_RU] = "Распределение случайной величины",
                [LANG_EN] = "Random variable distribution"
            },
            ["groupBox3"] = new()
            {
                [LANG_RU] = "Управление",
                [LANG_EN] = "Controls"
            },
            ["groupBox4"] = new()
            {
                [LANG_RU] = "Результаты накопления и обработки",
                [LANG_EN] = "Measurement results"
            },
            ["label1"] = new()
            {
                [LANG_RU] = "Время счёта, с",
                [LANG_EN] = "Time elapsed, s"
            },
            ["label2"] = new()
            {
                [LANG_RU] = "за",
                [LANG_EN] = "over"
            },
            ["label3"] = new()
            {
                [LANG_RU] = "Мгновенная скорость счёта, имп./с:",
                [LANG_EN] = "Instantaneous count rate, imp./s:"
            },
            ["label4"] = new()
            {
                [LANG_RU] = "имп/с",
                [LANG_EN] = "imp/s"
            },
            ["label5"] = new()
            {
                [LANG_RU] = "=",
                [LANG_EN] = "="
            },
            ["label6"] = new()
            {
                [LANG_RU] = "Время фильтра:",
                [LANG_EN] = "Averaging time:"
            },
            ["label8"] = new()
            {
                [LANG_RU] = "Таймер отсчёта:",
                [LANG_EN] = "Time elapsed:"
            },
            ["label9"] = new()
            {
                [LANG_RU] = "Общее кол-во импульсов",
                [LANG_EN] = "Total number of counts"
            },
            ["label10"] = new()
            {
                [LANG_RU] = "=",
                [LANG_EN] = "="
            },
            ["label11"] = new()
            {
                [LANG_RU] = "с",
                [LANG_EN] = "s"
            },
            ["label12"] = new()
            {
                [LANG_RU] = "Математическое ожидание",
                [LANG_EN] = "Expected value"
            },
            ["label13"] = new()
            {
                [LANG_RU] = "с",
                [LANG_EN] = "s"
            },
            ["label14"] = new()
            {
                [LANG_RU] = "Расширенный режим",
                [LANG_EN] = "Advanced mode"
            },
            ["label15"] = new()
            {
                [LANG_RU] = "Дисперсия",
                [LANG_EN] = "Variance"
            },
            ["label16"] = new()
            {
                [LANG_RU] = "Среднеквадратичное отклонение",
                [LANG_EN] = "Standard deviation"
            },
            ["label17"] = new()
            {
                [LANG_RU] = "Количество событий",
                [LANG_EN] = "Number of events"
            },
            ["label19"] = new()
            {
                [LANG_RU] = "Плотность потока, 1/(мин ⋅см²)",
                [LANG_EN] = "Particle fluence rate, 1/(min⋅cm²)"
            },
            ["label20"] = new()
            {
                [LANG_RU] = "МАЭД, мкЗв/ч",
                [LANG_EN] = "Dose rate, μSv/h"
            },
            ["label22"] = new()
            {
                [LANG_RU] = "Коэф.",
                [LANG_EN] = "Coeff."
            },
            ["label23"] = new()
            {
                [LANG_RU] = "b",
                [LANG_EN] = "b"
            },
            ["label24"] = new()
            {
                [LANG_RU] = "g",
                [LANG_EN] = "g"
            },
            ["label25"] = new()
            {
                [LANG_RU] = "Коэф.",
                [LANG_EN] = "Coeff."
            },
            ["label26"] = new()
            {
                [LANG_RU] = "Средняя скорость счёта",
                [LANG_EN] = "Average count rate"
            },
            ["label27"] = new()
            {
                [LANG_RU] = "скорость",
                [LANG_EN] = "rate"
            },
            ["label28"] = new()
            {
                [LANG_RU] = "счёта",
                [LANG_EN] = "count"
            },
            ["label30"] = new()
            {
                [LANG_RU] = "c:",
                [LANG_EN] = "s:"
            },
            ["label37"] = new()
            {
                [LANG_RU] = "Время накопления статистики:",
                [LANG_EN] = "Measurement time:"
            },
            ["label32"] = new()
            {
                [LANG_RU] = "накопления",
                [LANG_EN] = "Measurement"
            },
            ["label7"] = new()
            {
                [LANG_RU] = "статистики:",
                [LANG_EN] = "time:"
            },
            ["label33"] = new()
            {
                [LANG_RU] = "Статус соединения",
                [LANG_EN] = "Connection status"
            },
            ["label34"] = new()
            {
                [LANG_RU] = "Скорость счёта, имп./с",
                [LANG_EN] = "Count Rate, imp./s"
            },
            ["label35"] = new()
            {
                [LANG_RU] = "Расширенный режим",
                [LANG_EN] = "Advanced mode"
            },
            ["label36"] = new()
            {
                [LANG_RU] = "Соединение",
                [LANG_EN] = "Connection"
            },
            ["ButtonStartStop"] = new()
            {
                [LANG_RU] = "СТОП",
                [LANG_EN] = "STOP"
            },
            ["ButtonDistrArchive"] = new()
            {
                [LANG_RU] = "Архив",
                [LANG_EN] = "Archive"
            },
            ["ButtonDistrExport"] = new()
            {
                [LANG_RU] = "Экспорт CSV",
                [LANG_EN] = "Export CSV"
            },
            ["ButtonDistrReset"] = new()
            {
                [LANG_RU] = "Сброс",
                [LANG_EN] = "Reset"
            },
            ["ButtonSimpleStop"] = new()
            {
                [LANG_RU] = "СТОП",
                [LANG_EN] = "STOP"
            },
            ["ButtonSimpleStart"] = new()
            {
                [LANG_RU] = "ПУСК",
                [LANG_EN] = "START"
            },
            ["tabPage1"] = new()
            {
                [LANG_RU] = "Simple",
                [LANG_EN] = "Simple"
            },
            ["tabPage2"] = new()
            {
                [LANG_RU] = "Advance",
                [LANG_EN] = "Advance"
            },

            // ============================================================
            // FormArchive controls
            // ============================================================
            ["FA_groupBox1"] = new()
            {
                [LANG_RU] = "График скорости счёта",
                [LANG_EN] = "Count rate graph"
            },
            ["FA_groupBox2"] = new()
            {
                [LANG_RU] = "Распределение случайной величины",
                [LANG_EN] = "Random variable distribution"
            },
            ["FA_groupBox3"] = new()
            {
                [LANG_RU] = "Выбор интервала данных",
                [LANG_EN] = "Data interval selection"
            },
            ["FA_groupBox4"] = new()
            {
                [LANG_RU] = "Результаты накопления и обработки",
                [LANG_EN] = "Measurement results"
            },
            ["FA_label1"] = new()
            {
                [LANG_RU] = "Время накопления",
                [LANG_EN] = "Measurement time"
            },
            ["FA_label2"] = new()
            {
                [LANG_RU] = "Начало",
                [LANG_EN] = "Start"
            },
            ["FA_label3"] = new()
            {
                [LANG_RU] = "Дата",
                [LANG_EN] = "Date"
            },
            ["FA_label6"] = new()
            {
                [LANG_RU] = "Окончание",
                [LANG_EN] = "End"
            },
            ["FA_label12"] = new()
            {
                [LANG_RU] = "Математическое ожидание",
                [LANG_EN] = "Expected value"
            },
            ["FA_label15"] = new()
            {
                [LANG_RU] = "Дисперсия",
                [LANG_EN] = "Variance"
            },
            ["FA_label16"] = new()
            {
                [LANG_RU] = "Среднеквадратичное отклонение",
                [LANG_EN] = "Standard deviation"
            },
            ["FA_label17"] = new()
            {
                [LANG_RU] = "Количество событий",
                [LANG_EN] = "Number of events"
            },

            ["FA_ButtonDistrExport"] = new()
            {
                [LANG_RU] = "Экспорт CSV",
                [LANG_EN] = "Export CSV"
            },
            ["FA_ButtonDistrRefresh"] = new()
            {
                [LANG_RU] = "Обновить",
                [LANG_EN] = "Refresh"
            },
        };

        // ============================================================
        // Non-control strings (used in code, not in designer)
        // ============================================================
        private static readonly Dictionary<string, Dictionary<string, string>> StringTranslations = new()
        {
            ["Stop"] = new()
            {
                [LANG_RU] = "СТОП",
                [LANG_EN] = "STOP"
            },
            ["Start"] = new()
            {
                [LANG_RU] = "ПУСК",
                [LANG_EN] = "START"
            },
            ["Auto"] = new()
            {
                [LANG_RU] = "Авто",
                [LANG_EN] = "Auto"
            },
            ["SecondsSuffix"] = new()
            {
                [LANG_RU] = "с",
                [LANG_EN] = "s"
            },
            ["DefaultSettingsLoaded"] = new()
            {
                [LANG_RU] = "Загружены настройки по умолчанию",
                [LANG_EN] = "Default settings loaded"
            },
            ["SaveCsvTitle"] = new()
            {
                [LANG_RU] = "Сохранить данные в файл .csv",
                [LANG_EN] = "Save data to .csv file"
            },
            ["SaveCsvError"] = new()
            {
                [LANG_RU] = "Ошибка при сохранении файла",
                [LANG_EN] = "Error saving file"
            },
            ["AdvancedMode"] = new()
            {
                [LANG_RU] = "Расширенный режим",
                [LANG_EN] = "Advanced mode"
            },
            ["SimpleMode"] = new()
            {
                [LANG_RU] = "Упрощенный режим",
                [LANG_EN] = "Simplified mode"
            },
        };

        /// <summary>
        /// Get translated text for a control by its Name.
        /// </summary>
        public static string GetText(string controlName)
        {
            if (Translations.TryGetValue(controlName, out var langDict))
            {
                if (langDict.TryGetValue(_currentLanguage, out var text))
                    return text;
            }
            return controlName; // fallback: return key name
        }

        /// <summary>
        /// Get translated string by key (for non-control strings).
        /// </summary>
        public static string GetString(string key)
        {
            if (StringTranslations.TryGetValue(key, out var langDict))
            {
                if (langDict.TryGetValue(_currentLanguage, out var text))
                    return text;
            }
            return key; // fallback: return key name
        }

        /// <summary>
        /// Toggle current language between "ru" and "en".
        /// </summary>
        public static void ToggleLanguage()
        {
            _currentLanguage = _currentLanguage == LANG_RU ? LANG_EN : LANG_RU;
        }
    }
}
