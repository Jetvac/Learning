$(document).ready(function () {
    function deleteClassByClassName(className, deletedClass) {
        var i, tabcontent;

        tabcontent = document.getElementsByClassName(className);
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].className = tabcontent[i].className.replace(" " + deletedClass, "");
        }
    }

    function openTab(tabName) {
        deleteClassByClassName("active-place__tab", "active-tab");
        
        document.getElementById(tabName).className += " active-tab";
    }
    function setButtonActive(buttonName) {
        deleteClassByClassName("menu-panel__button", "tab-button_active");

        document.getElementById(buttonName).className += " tab-button_active";
    }

    $('#courses-button').click(function(e) {
        setButtonActive('courses-button');
        openTab('course-panel');
    });
    $('#courses-button-1').click(function(e) {
        setButtonActive('courses-button-1');
    });
    $('#add-course__navigate-button').click(function(e) {
        openTab('course-add-panel');
    });
});