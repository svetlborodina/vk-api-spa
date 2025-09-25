<template>
    <div id="app">
        <div class="container">
            <div class="card border-0 shadow my-5">
                <div class="card-body p-5">
                    <navigation />
                    <router-view></router-view>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import navigation from './components/navigation.vue'

    export default {
        name: 'app',
        components: {
            navigation
        }
    }
</script>

<style>
    #app {
      font-family: Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      color: #2c3e50;
      margin-top: 60px;
    }

    body {
      background: url('../img/bg.png') repeat;
    }
</style>
