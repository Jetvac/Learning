// Проверка на то, что str — число
function isNumber (str)
{
    return (+str !== NaN);
}

// Проверка даты на соответствие маске dd.mm.yyyy
function dateFormatCheck (date) 
{
    return isNaN(Date.parse(date));
}

// Экспорт функций
export {isNumber, dateFormatCheck}