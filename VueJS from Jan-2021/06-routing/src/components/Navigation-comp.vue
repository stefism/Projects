<template>
  <el-menu
    class="el-menu-demo"
    mode="horizontal"
  >
    <el-menu-item index="1">
      <router-link :to="{ name: 'home' }">Home</router-link>
      <!-- Можем да сложим параметър на router-link примерно tag="button" и тогава линка ще се генерира в елемент бутон. -->
      <!-- Когато имаме наименуван раут, ето така се слага в този обект :to="{ name: 'home' } -->
    </el-menu-item>

    <el-menu-item index="2">
      <router-link to="/magic-books">Magic Books</router-link>
      <!-- За да работят линковете с раутъра, трябва да ги заграждаме в този таг, който също идва от vue-router библиотеката. Когато нямама именуван раут, а изписваме реалния url, не слагаме двете точки пред to - to="/magic-books" -->
    </el-menu-item>

    <el-menu-item index="3">
      <router-link to="/form">Form</router-link>
    </el-menu-item>

    <el-menu-item index="4">
      <router-link to="/bookshelves">Bookshelves</router-link>
      <!-- <router-link :to="{ name: 'favourites' }">Bookshelves</router-link> -->
      <!-- Тук можем и директно да подадем името на чайд раута и така да прескочим този междинен компонент и да не редиректваме в books.js. -->
    </el-menu-item>
  </el-menu>
</template>

<script>
export default {};
</script>

<style></style>