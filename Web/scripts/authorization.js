const ADDRESS = `https://localhost`;
const PORT = `44316`;
const IP = `${ADDRESS}:${PORT}`;

$(document).ready(function () {
    // Авторизация
    $(`#login-button`).click(function (e) {
        e.preventDefault();
        var login = $(`#login`).val();
        var password = $(`#password`).val();

        // POST запрос на аторизацию к API
        $.ajax({
            url: `${IP}/auth`,
            type: `POST`,
            contentType: `application/text; charset=utf-8`,
            data: `${login}\n${password}`,
            success: function (response) {
                if (response == "") {
                    alert(`Неверный логин или пароль`);
                } else {
                    alert(response);
                    document.location.href = `${IP}/courses`
                    // $.ajax({
                    //     url: `${IP}/courses`,
                    //     type: `GET`,
                    //     contentType: 'application/text; charset=utf-8',
                    //     success: function (response) {

                    //     }
                    // })
                }

                // Очистка поля ввода пароля
                $(`#password`).val(``);
            }
        });
    });
});