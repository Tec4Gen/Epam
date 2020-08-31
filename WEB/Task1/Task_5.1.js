function MyFunc() {
        let punctuations = ".,:;!?";

        let str = "У. попа. была: собака";
        let arrayWord;
        for (let index = 0; index < punctuations.length; index++) {
                arrayWord = str.split(punctuations[index])
                str = arrayWord.join("")
        }
        
        arrayWord = str.split(" ");
        str = arrayWord.join(" ");
        
        let count = 0;
        for (let i = 0; i < arrayWord.length; i++) {
                for (let j = 0; j < arrayWord[i].length; j++) {
                        for (let index = 0; index < arrayWord[i].length; index++) {
                                if (arrayWord[i][j] === arrayWord[i][index]) {
                                        count++;
                                }
                        }
                        if (count > 1) {
                                str = str.split(arrayWord[i][j]).join("")     
                        }
                        count = 0;
                }
        }
        console.log(str);
}


MyFunc();