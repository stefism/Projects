import Vue from 'vue';
import Vuex from 'vuex';

import firebase from 'firebase/app';
import 'firebase/auth';
import db from '../firebase/firebaseInit.js';


Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    blogPosts: [],
    postLoaded: null,
    blogHTML: 'Напишете тук заглавието на поста',
    blogTitle: '',
    blogPhotoName: '',
    blogPhotoFileURL: null,
    blogPhotoPreview: null,
    editPost: null,
    user: null,
    profileAdmin: null,
    profileEmail: '',
    profileFirstName: '',
    profileLastName: '',
    profileUserName: '',
    profileId: null,
    profileInitials: ''
  },
  getters: {
    blogPostsFeed(state) {
      return state.blogPosts.slice(0, 2);
    },
    blogPostCards(state) {
      return state.blogPosts.slice(2, 6);
    }
  },
  mutations: {
    newBlogPost(state, payload) {
      state.blogHTML = payload;
    },
    updateBlogTitle(state, payload) {
      state.blogTitle = payload;
    },
    fileNameChange(state, payload) {
      state.blogPhotoName = payload;
    },
    createFileURL(state, payload) {
      state.blogPhotoFileURL = payload;
    },
    openPhotoPreview(state) {
      state.blogPhotoPreview = !state.blogPhotoPreview;
    },
    toggleEditPost(state, payload) {
      state.editPost = payload;
    },
    setBlogState(state, currentBlog) {
      state.blogTitle = currentBlog.blogTitle;
      state.blogHTML = currentBlog.blogHTML;
      state.blogPhotoFileURL = currentBlog.blogCoverPhoto;
      state.blogPhotoName = currentBlog.blogCoverPhotoName;
    },
    filterBlogPost(state, blogPostId) {
      state.blogPosts = state.blogPosts.filter(post => post.blogId != blogPostId);
    },
    updateUser(state, payload) {
      state.user = payload;
    },
    setProfileAdmin(state, isAdmin) {
      state.profileAdmin = isAdmin;
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
    },
    changeFirstName(state, payload) {
      state.profileFirstName = payload;
    },
    changeLastName(state, payload) {
      state.profileLastName = payload;
    },
    changeUserName(state, payload) {
      state.profileUserName = payload;
    }
  },
  actions: {
    async getCurrentUser({ commit }, user) {
      const dataBase = await db.collection('users').doc(firebase.auth().currentUser.uid);
      const dbResult = await dataBase.get();

      commit('setProfileInfo', dbResult);
      commit('setProfileInitials');
      
      const token = await user.getIdTokenResult();
      const isAdmin = await token.claims.email == 'stef4otm@gmail.com';
      commit('setProfileAdmin', isAdmin);
    },
    async updateUserSettings({ commit, state }) {
      const dataBase = await db.collection('users').doc(state.profileId);
      await dataBase.update({
        firstName: state.profileFirstName,
        lastName: state.profileLastName,
        username: state.profileUserName
      });
      commit('setProfileInitials');
    },
    async getPost({ state }) {
      const dataBase = await db.collection('blogPosts').orderBy('date', 'desc');
      const dbResults = await dataBase.get();
      
      dbResults.forEach(doc => {
        if(!state.blogPosts.some(post => post.blogId == doc.id)) {
          const data = {
            blogId: doc.data().blogId,
            blogHTML: doc.data().blogHTML,
            blogCoverPhoto: doc.data().blogCoverPhoto,
            blogTitle: doc.data().blogTitle,
            blogDate: doc.data().date,
            blogCoverPhotoName: doc.data().blogCoverPhotoName
          };

          state.blogPosts.push(data);
        }
      });

      state.postLoaded = true;
    },
    async updatePost({ commit, dispatch }, blogPostId) {
      commit('filterBlogPost', blogPostId);
      await dispatch('getPost');
    },
    async deletePost({ commit }, blogPostId) {
      const post = await db.collection('blogPosts').doc(blogPostId);
      await post.delete();
      commit('filterBlogPost', blogPostId);
    }
  },
  modules: {
  }
})
