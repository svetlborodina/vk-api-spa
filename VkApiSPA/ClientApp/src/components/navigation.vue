<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark mb-4">
        <div class="collapse navbar-collapse">
            <ul class="navbar-nav mr-auto">
                <router-link to="/token" v-slot="{ href, route, navigate, isActive }">
                    <li class="nav-item" v-bind:class="{ active: isActive }">
                        <a class="nav-link" :href="href" @click="navigate">{{ route.name }}</a>
                    </li>
                </router-link>
                <router-link to="/groups" v-slot="{ href, route, navigate, isActive }">
                    <li class="nav-item" v-bind:class="{ active: isActive }">
                        <a class="nav-link" :href="href" @click="navigate">{{ route.name }}</a>
                    </li>
                </router-link>
            </ul>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'navigation'
    }
</script>
