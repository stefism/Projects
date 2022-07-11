import axios from 'axios';

const initialState = {
    id: null,
    name: 'n/a',
    status: '',
    species: '',
    type: '',
    gender: '',
    origin: null,
    location: null,
    image: '',
    episode: [],
    url: '',
    created: ''
}

export default {
    namespaced: true, //Когато имаме стейт на модули, това трябва да го има.
    state: {
        userData: { ...initialState },
        isLoading : false
    },
    getters: {
        isLoading(state) {
            return state.isLoading;
        },
        userData(state) {
            return state.userData;
        }
    },
    mutations: {
        resetUserState(state) {
            state.userData = { ...initialState };
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
        setCharacter(state, payload) {
            state.userData = payload;
        }
    },
    actions: {
        async getUser(context, userId) {
            context.commit('setLoadingState', { isLoading: true });
            const responce = await axios.get('https://rickandmortyapi.com/api/character/' + userId);
            context.commit('setCharacter', responce.data);
            context.commit('setLoadingState', { isLoading: true });
        }
    }
}