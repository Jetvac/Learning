// Проверка на то, что str — число
function isNumber (str)
{
    return (+str !== NaN);
}

// Проверка формата даты
function dateFormatCheck (date) 
{
    return isNaN(Date.parse(date));
}

// Экспорт функций
export {isNumber, dateFormatCheck}