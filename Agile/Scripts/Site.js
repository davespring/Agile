$(document).ready(function () {

    $("#add-user-btn").on("click", function () {
        console.log("Add User Button Clicked");
        $("#AddUserModal").openModal();
    });


    $("#add-story-btn").on("click", function () {
        console.log("Add Story Button Clicked");
        $("#AddStoryModal").openModal();
    });

    $("#users-list-btn").on("click", function () {
        console.log("users-list-btn-clicked");
        $("#UsersListModal").openModal();
    });

});


