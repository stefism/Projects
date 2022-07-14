import Vue from 'vue';
import Vuex from 'vuex';

import firebase from 'firebase/app';
import 'firebase/auth';
import db from '../firebase/firebaseInit.js';


Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    sampleBlogCards: [
      { blogTitle: 'Блог карта 1', blogCoverPhoto: 'stock-1', blogDate: '1 Май 2022 г.'},
      { blogTitle: 'Блог карта 2', blogCoverPhoto: 'stock-2', blogDate: '15 Май 2022 г.'},
      { blogTitle: 'Блог карта 3', blogCoverPhoto: 'stock-3', blogDate: '11 Юни 2022 г.'},
      { blogTitle: 'Блог карта 4', blogCoverPhoto: 'stock-3', blogDate: '12 Юли 2022 г.'}
    ],
    editPost: null,
    user: null,
    profileEmail: '',
    profileFirstName: '',
    profileLastName: '',
    profileUserName: '',
    profileId: null,
    profileInitials: ''
  },
  mutations: {
    toggleEditPost(state, payload) {
      state.editPost = payload;
    },
    updateUser(state, payload) {
      state.user = payload;
    },
    setProfileInfo(state, dbResult) {
      state.profileId = dbResult.id;
      state.profileEmail = dbResult.data().email;
      state.profileFirstName = dbResult.data().firstName;
      state.profileLastName = dbResult.data().lastName;
      state.profileUserName = dbResult.data().username;
    },
    setProfileInitials(state) {
      state.profileInitials = state.profileFirstName.charAt(0) + state.profileLastName.charAt(0);
    }
  },
  actions: {
    async getCurrentUser({ commit }) {
      const dataBase = await db.collection('users').doc(firebase.auth().currentUser.uid);
      const dbResult = await dataBase.get();

      commit('setProfileInfo', dbResult);
      commit('setProfileInitials');
      console.log(dbResult);
    }
  },
  modules: {
  }
})
