const ADDRESS = 'https://localhost';
const PORT = '44316';
const IP = `${ADDRESS}:${PORT}`;

$(document).ready(function () {
    $('#login-button').click(function (e) {
        e.preventDefault();
        var login = $('#login').val();
        var password = $('#password').val();

        // POST запрос к API
        $.ajax({
            url: `${IP}/authorization`,
            type: 'POST',
            contentType: 'application/text; charset=utf-8',
            data: `${login}\n${password}`,
            success: function (response) {
                if (response == "")
                {
                    alert('Неверный логин или пароль');
                }
                else
                {
                    alert (response);
                }
                
                // Очистка поля ввода пароля
                $('#password').val('');
            }
        });
    });
});