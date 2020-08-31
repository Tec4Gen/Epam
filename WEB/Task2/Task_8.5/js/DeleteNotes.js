import {ArrayNote} from "./CreateNote.js";

let note = document.querySelector('#notes__list');
export let flag = false;

note.addEventListener("click", deleteItem, event);

function deleteItem(event) {
    const target = event.target;
    
    if(target.tagName == 'BUTTON') {
        flag = true;
        let qua = confirm('Вы действительно хотите удалить заметку?');
        if(qua) {
            let parent = target.parentElement.parentElement;
            parent.remove();

            let id = target.id.split('-')[3];
            ArrayNote.deleteById(id);
        }
    }
}

export function toggleFlag() {
    flag = !flag;
}
