﻿let table = document.querySelector('#table');
let body = document.querySelector("body");
let modal = document.getElementById('fixed-overlay');
let mainBtn_close = document.getElementById("b__close__edit");
let mainBtn_close_ = document.getElementById("close");
let form = document.getElementById("DeleteAll");
table.addEventListener("click", actionModal, event);

function actionModal(event) {

    const target = event.target;
    console.log(target.name);
    if (target.name == 'btnD') {
        let id = target.id.split('-')[1];
        form.action = `Redirect/RedirectWithAwardForDelete.cshtml?AwardId=${id}`;
        modal.classList.toggle("show");
    }
}

mainBtn_close.onclick = function () {
    modal.classList.toggle("show");
}


mainBtn_close_.onclick = function () {

    modal.classList.toggle("show");
}