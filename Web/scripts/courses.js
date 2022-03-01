const ADDRESS = `https://localhost`;
const PORT = `44316`;
const IP = `${ADDRESS}:${PORT}`;

$(document).ready(function () {
    // Добавление пройденных курсов
    $.ajax({
        url: `${IP}/GetCompletedCourses`,
        type: `GET`,
        contentType: `application/text; charset=utf-8`,
        success: function (response) {
            Object.keys(response).forEach((index) => {
                $(`#course-list`).append($(`<div class="course-item">
                <div class="course-item__header">
                    <img class="course-item__icon-img" src="./GetCourseImage">
                </div>
                <div class="course-item__body">
                    <div class="course-item__title">“${response[index][`courseName`]}”</div>
                    <div class="course-item__hours-text">${response[index][`hoursCount`]} ч.</div>
                </div>
                <div class="course-item__footer">
                    <div class="course-item__educate-organisation-text">${response[index][`educationOrganisationName`]}</div>
                </div>
            </div>`))
            });

        }
    });
    // Добавление наименований образовательных организаций
    $.ajax({
        url: `${IP}/GetEducationOrganisation`,
        type: `GET`,
        contentType: `application/text; charset=utf-8`,
        success: function (response) {
            Object.keys(response).forEach((index) => {
                $(`#education-place-selector`).append(`<option value="${response[index]['educationOrganisationId']}">${response[index]['educationOrganisationName']}</option>`);
            });
        }
    });
});