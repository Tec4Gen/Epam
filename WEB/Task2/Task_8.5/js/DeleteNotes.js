import {Service} from "./MyArray.js";

import {ArrayNote, bodyNode} from "./CreateNote.js";
let a = document.querySelector('#notes__list');
a.addEventListener("click", deleteItem, event);
console.log(a);
function deleteItem(event) {
    const target = event.target;
    console.log(target.tagName);

    if(target.tagName == 'BUTTON') {
        let qua = confirm('Вы действительно хотите удалить заметку?');
        if(qua) {
            let parent = target.parentElement.parentElement;
            parent.remove();
        }
        
    }
}
