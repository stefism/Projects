<template>
  <div>
    <h2>Characters table</h2>
    <el-pagination
        v-if="pagination"
        background 
        layout="prev, pager, next"
        :page-count="pagination.pages"
        @current-change="onCurrentCange"
    >
    </el-pagination>
    <el-table :data="characters" v-loading="isLoading">
      <!-- v-loading - директива, която също идва от ElementUI. -->
      <el-table-column prop="name" label="Name"> </el-table-column>
      <el-table-column prop="gender" label="Gender"> </el-table-column>
      <el-table-column prop="species" label="Species"> </el-table-column>
    </el-table>
    <el-pagination
        v-if="pagination"
        background 
        layout="prev, pager, next"
        :current-page="page"
        :page-count="pagination.pages"
        @current-change="onCurrentCange"
    >
    </el-pagination>
  </div>
</template>
<script>
import axios from "axios";

export default {
  data() {
    return {
      characters: [],
      pagination: null,
      isLoading: true,
      page: 1
    };
  },
  methods: {
    async fetchCharacters() {
      const url = `https://rickandmortyapi.com/api/character/?page=${this.page}`;

      try {
        const responce = await axios.get(url);
        console.log("result: ", responce);
        this.characters = responce.data.results;
        this.pagination = responce.data.info;
      } catch (error) {
        console.error("Error while loading.", error);
      }
    },
    onCurrentCange(page) {
        this.page = page;
        this.isLoading = true;
        this.fetchCharacters(page);
        this.isLoading = false;
        //Тук page се подава автоматчно от елемента el-pagination на ElementUI библиотеката през евента @current-change.
    }
  },
  async created() {
    //created() - live cycle
    await this.fetchCharacters();
    this.isLoading = false;
  },
};
</script>

<style></style>
