function extensibleObject() { 
    const proto = {};
    const instance = Object.create(proto); //Създаваме обект instance, който е празен и има за прототип proto.

    instance.extend = function(objectThatBeCloned) {
        Object.entries(objectThatBeCloned).forEach(([key, value]) => {
            if(typeof value == 'function') {
                proto[key] = value;
            } else {
                instance[key] = value;
            }
        });
    };

    return instance;
}   