import {ArrayNote, bodyNode} from "./CreateNote.js";
import {flag, toggleFlag} from "./DeleteNotes.js";

let modal = document.getElementById("ModalEdit");
let mainBtn_close = document.getElementById("b__close__edit");
let mainBtn_save = document.getElementById("b__edit");
let note = document.querySelector('#notes__list');
let tempNote;
note.addEventListener("click", editItem, event);

function editItem(event) {

    if(flag) {
        toggleFlag();
        console.log(1);
        return;
    }

    const target = event.target;

    if(target.className == "note-text-body" || target.className == "note-text-head" || target.className == "note__item-text") {
        let array = target.id.split('-');
        let index =  array.length - 1;
        console.log(index);
        tempNote = ArrayNote.getById(array[index]);

        bodyNode.getElementById("modal-content-head-edit").innerHTML = tempNote.querySelectorAll("span")[0].innerHTML;
        bodyNode.getElementById("modal-content-body-edit").innerHTML = tempNote.querySelectorAll("span")[1].innerHTML;

        modal.classList.toggle("btn__show");

        return;
    }
}

mainBtn_close.onclick = function() {
    modal.classList.toggle("btn__show");
    bodyNode.getElementById("modal-content-head").innerHTML = '';
    bodyNode.getElementById("modal-content-body").innerHTML = '';
}

mainBtn_save.onclick = function() {
    let first = bodyNode.getElementById(tempNote.id);
    console.log(first);
    first.querySelectorAll("span")[0].innerHTML =  bodyNode.getElementById("modal-content-head-edit").innerHTML;
    first.querySelectorAll("span")[1].innerHTML =  bodyNode.getElementById("modal-content-body-edit").innerHTML;

    note.prepend(first);

    let index = tempNote.id.split('-')[1];

    ArrayNote.updateById(index, first);

    modal.classList.toggle("btn__show");
    bodyNode.getElementById("modal-content-head").innerHTML = '';
    bodyNode.getElementById("modal-content-body").innerHTML = '';
}
  