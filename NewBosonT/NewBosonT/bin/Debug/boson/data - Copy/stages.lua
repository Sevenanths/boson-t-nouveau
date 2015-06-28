stages = {
    -- STAGE 1
    {
        initial_speed = 0.7,
        max_speed = 1.2,
        energy_interval = 6,
        energy_speedup = 0.00135,
        level_depth = 28,
        particle_name = "geon",
        particle_abbv = "ge",
    },
}

num_stages = 1

-- Set stage ids
for i = 1, num_stages do
    stages[i].id = i
end

function get_stage(stage_id)
    --return stages[num_stages]
    return stages[math.min(num_stages, stage_id)]
end

function is_unlocked(s)
    return s == 1
        or s == 2 and lt.state.stage_finished[1]
        or s == 3 and lt.state.stage_finished[2]
        or s == 4 and lt.state.stage_finished[1]
        or s == 5 and lt.state.stage_finished[4]
        or s == 6 and lt.state.stage_finished[5] and lt.state.stage_finished[3]
end

function compute_progress()
    --if 1 == 1 then return 6 end
    local stage = 0
    for s = 1, num_stages do
        if lt.state.stage_finished[s] then
            stage = stage + 1
        end
    end
    return stage
end
