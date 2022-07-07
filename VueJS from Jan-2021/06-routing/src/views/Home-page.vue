<template>
  <section>
    <img alt="Vue logo" src="@/assets/logo.png" />
    <h1>Vue Demo App with routing</h1>
    <p>
      We are using Google's Books API, more on that here:
      <a href="https://developers.google.com/books/docs/v1/using"
        >Using the API</a
      >
    </p>
    <p>
      Also you need to set your Google Book API Key in a .env file as
      'VUE_APP_BOOKS_KEY'
    </p>

    <el-button type="primary" @click="onAuthUser">Authenticate me</el-button>
  </section>
</template>

<script>
import { authMe } from '../utils/authUtils.js';
export default {
  methods: {
    onAuthUser() {
      authMe();
    }
  }
};
</script>

<style></style>