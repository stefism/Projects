<template>
  <div class="navigation">
    <ul>
      <li v-for="nav in navigationItems" :key="nav.id">
        <a href="#" @click.prevent="onMenuClick(nav.id)">{{nav.name}}</a>
        <!-- Докато извъртаме в цикъла v-for всички navigationItems, на всеки един айтем му закачаме клик евент и подаваме като параметър на този евент, съответното ай ди на айтема. Искаме този евент да го изпратим на парент компонента, за да може той да разбере, кога е кликнато на бутон от менюто. Затова, долу в метода onMenuClick подаваме нагоре към парента като $emit, къстъм евент, който сме кръстили  nav-click. navigationItems ги получаваме като пропс от парент компонента. -->
      </li>
    </ul>

    <ul>
      <li><a href="#" @click="$emit('on-create-subject')">SUBJECT [+]</a></li>
      <!-- Може и така директно да подаваме нагоре емита. В случая не подаваме данни, а само събитието. -->
    </ul>
  </div>
</template>

<script>
export default {
  props: {
    navigationItems: {
      type: Array,
      required: true
    }
  },
  methods: {
    onMenuClick(id) {
      this.$emit('nav-click', id);
      //Ето тук подаваме къстъм евента и заедно с него, автоматично към парент компонента, заедно с къстъм евента, ще се предаде и параметъра, който сме закачили след името на евента. В случая id.
    }
  }
}
</script>

<style>

</style>