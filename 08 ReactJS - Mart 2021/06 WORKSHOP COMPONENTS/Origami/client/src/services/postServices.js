import api from './api';

export const getAll = async () => {
   try {
        const result = await fetch(api.posts);
        return await result.json();
    } catch (err) {
        return console.log("Error: " + err);
    }
};

 //резултата от result.json() е промис, който ще се получи в gеtAll