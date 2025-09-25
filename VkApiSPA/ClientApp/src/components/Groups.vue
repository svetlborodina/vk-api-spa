<template>
    <div>
        <div class="card mb-3">
            <div class="card-header bg-primary text-white font-weight-bold">
                Группы
            </div>
            <div class="card-body">
                <form @submit.prevent="leaveGroups">
                    <div class="form-group">
                        <label for="userId">UserID</label>
                        <input
                            type="text"
                            class="form-control"
                            v-model="userId"
                            id="userId"
                            required
                            placeholder="Введите идентификатор пользователя"
                        />
                    </div>
                    <div class="form-group">
                        <label for="excludeIds">Exclude GroupIDs</label>
                        <textarea
                            cols="40" 
                            rows="5" 
                            class="form-control"
                            v-model="excludeIds"
                            id="excludeIds"
                            required
                            placeholder="Введите идентификаторы групп для исключения"
                        />
                    </div>
                    <button type="submit" class="btn btn-primary">
                        Покинуть группы
                    </button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'Groups',
        data() {
            return {
                excludeIds: null,
                userId: 111
            };
        },
        async mounted() {
            //this.$set(this, 'excludeIds', (await axios.get('/group')).data);
        },
        methods: {
            async leaveGroups() {
                const response = (await axios.post(`/group/leave?userId=${this.userId}`, {ExcludesIdsStr: this.excludeIds}, { headers: { 'content-type': 'application/json' } })).data;
                debugger;
            }
        }
    }
</script>

<style scoped>
</style>
