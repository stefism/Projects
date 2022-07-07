<template>
  <div v-loading="isLoading">
    <section v-if="book">
      <h1>{{ book.volumeInfo.title }}</h1>

      <el-breadcrumb separator="/">
        <el-breadcrumb-item :to="{ path: '/' }">Home</el-breadcrumb-item>
        <el-breadcrumb-item><a href="/">Books</a></el-breadcrumb-item>
        <el-breadcrumb-item>Preview</el-breadcrumb-item>
      </el-breadcrumb>

      <el-row :gutter="20">
        <el-col :span="8">
          <img :src="book.volumeInfo.imageLinks.thumbnail" alt="Book image" />
        </el-col>

        <el-col :span="16">
          <h2>About</h2>
          <ul>
            <li><b>Authors:</b> {{ book.volumeInfo.authors.join(" & ") }}</li>
            <li><b>Publisher:</b> {{ book.volumeInfo.publisher }}</li>
            <li><b>Published Date:</b> {{ book.volumeInfo.publishedDate }}</li>
            <li><b>Language:</b> {{ book.volumeInfo.language }}</li>
            <li ><b>Pages:</b> {{ book.volumeInfo.printedPageCount }}</li>
            <b>Description:</b><li v-html="book.volumeInfo.description"></li>
          </ul>

          <div>
            <el-button type="primary">infoLink</el-button>
            <el-button type="primary">previewLink</el-button>
          </div>
        </el-col>
      </el-row>
    </section>
  </div>
</template>

<script>
import { fetchSingleBook } from "../dataProviders/books";
export default {
  data() {
    return {
      isLoading: true,
      book: null,
    };
  },
  methods: {
    goBack() {
      console.warn("back");
    },
  },
  async created() {
    this.book = await fetchSingleBook(this.$route.params.bookId);
    this.isLoading = false;
  },
};
</script>

<style scoped>
h1 {
  text-align: left;
  margin-bottom: 12px;
}
section {
  max-width: 1000px;
  margin: 0 auto;
}
ul {
  padding: 0;
  margin: 0 0 2rem 0;
  list-style-type: none;
}
</style>