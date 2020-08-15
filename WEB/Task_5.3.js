class Service {
    #mapList = new Map();;
    #id = 0;

    add(value) {
        if (value === undefined || value === null)
            throw new SyntaxError(`value =>| invalid argument value`);

        this.#mapList.set(this.#id.toString(), value);
        this.#id++;
    }

    show() {
        this.#mapList.forEach((value, key) => {
            console.log(`${key}: ${value}`);
        });;
    }

    getById(keyString) {
        if (keyString === undefined || keyString === null)
            throw new SyntaxError(`value =>| invalid argument value`);

        if (this.#mapList.has(keyString.toString())) {
            return this.#mapList.get(keyString.toString());
        }

        return null;
    }
    deleteById(keyString) {
        if (keyString === undefined || keyString === null)
            throw new SyntaxError(`value =>| invalid argument value`);

        if (this.#mapList.has(keyString.toString())) {
            let result = this.getById(keyString);
            this.#mapList.delete(keyString.toString());

            return result;
        }

        return null;
    }

    updateById(keyString, value) {
        if ((keyString === undefined || keyString === null) ||
            (value === undefined))
            throw new SyntaxError(`value =>| invalid argument value`);

        if (this.#mapList.has(keyString.toString())) {
            this.#mapList.set(keyString.toString(), value);
            return true;
        }
        return false;
    }

    getAll() {
        return Array.from(this.#mapList.values());
    }
}

let a = new Service();
a.add(1);
a.add(2);
a.add({ 1: 1, 2: 2 });
a.show();
console.log(a.getAll());
a.updateById(60,null);
console.log(a.getAll());
