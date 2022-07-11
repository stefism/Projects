import axios from 'axios';
import Vue from 'vue';
import Vuex from 'vuex';

import userModule from './users.js';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        count: 2,
        testString: '',
        characters: [],
        isLoading: false,
        message: ''
    },
    getters: {
        getCounter(state) {
            return state.count;
        },
        getDouble(state) {
            return state.count * 2;
        },
        getLoadingState(state) {
            return state.isLoading;
        },
        message(state) {
            return state.message;
        }
    },
    mutations: {
        increment(state, payload) {
            state.count++;
            state.testString = payload.name;
            //payload в случая идва от App.vue, който го изпраща през incrementCount() метода.
        },
        setCharacters(state, payload) {
            state.characters = payload;
        },
        setLoadingState(state, payload) {
            if (payload.isLoading) {
                state.isLoading = payload.isLoading;
            } else {
                setTimeout(() => {
                    state.isLoading = payload.isLoading;
                }, 3000);
            }
        },
        message(state, newMessage) {
            state.message = newMessage; //Когато имаме само едно нещо в payload, може да не го подаваме като обект, а директно само него.
        }
    },
    actions: {
        //Екшъните се ползват при асинхронни операции.
        async getAllCharacters(context) {
            //Чрез контекст имаме достъп до всички мутатори, екшъни и т. н.

            context.commit('setLoadingState', { isLoading: true });

            const responce = await axios.get('https://rickandmortyapi.com/api/character');
            context.commit('setCharacters', responce.data.results); //axios връща нещата вdata.

            context.commit('setLoadingState', { isLoading: false });

            //.commit е ключова дума и с нея викаме мутатора, който сме написали в стора.
            //Ако искаме да променим нещо в стора, като втори параметър изпращаме payloadкато той е обект, защото можем да изпратим само един payload.
        }
    },
    modules: {
        userModule
    }
});