const mongoose = require('mongoose');
const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');

// Express 앱 생성
const app = express();

// 미들웨어 설정
app.use(bodyParser.json());
app.use(cors());

// MongoDB 연결
const uri = "mongodb+srv://s2uh9yun:sh04020900@gamet.lpmyb.mongodb.net/?retryWrites=true&w=majority&appName=Gamet";
mongoose.connect(uri).then(() => {
    console.log("Connected to MongoDB!");
}).catch(err => {
    console.error("Failed to connect to MongoDB:", err);
});

// 사용자 스키마 및 모델
const userSchema = new mongoose.Schema({
    username: String,
    password: String,
    level: Number,
    experience: Number,
});
const User = mongoose.model('User', userSchema);

// 회원가입 API
app.post("/register", async (req, res) => {
    const { username, password } = req.body;
    const existingUser = await User.findOne({ username });

    if (existingUser) {
        res.json({ success: false, message: "Username already exists" });
    } else {
        const user = new User({ username, password, level: 1, experience: 0 });
        await user.save();
        res.json({ success: true, message: "User registered successfully!" });
    }
});

// 로그인 API
app.post("/login", async (req, res) => {
    const { username, password } = req.body;
    const user = await User.findOne({ username, password });

    if (user) {
        res.json({ success: true, message: "Login successful", user });
    } else {
        res.json({ success: false, message: "Invalid username or password" });
    }
});

// 서버 실행
const PORT = 3000;
app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});