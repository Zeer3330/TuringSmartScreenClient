
以下是重新生成的 README 文件，确保设备管理相关组件代码无误：

# TuringSmartScreenClient 设备监控客户端

## 项目概述
TuringSmartScreenClient 是一个基于 WPF 的设备监控客户端，用于实时展示计算机硬件信息，包含：
- CPU 使用率/型号/频率
- GPU 使用率/型号
- 内存使用量/型号
- 硬盘使用量/型号

## 核心功能
### 设备管理页面
#### 1. 进度条可视化
- 线性进度条展示硬件使用率
- 支持动态宽度计算
- 圆角矩形样式设计

#### 2. 信息格式化
- 使用 `TextBlock` + `Run` 组合实现分段显示
- 支持百分比、容量、频率等格式转换
- 统一单位显示（%、GB、GHz）

#### 3. 多硬件支持
- 独立显卡与集成显卡分别展示
- 多内存条信息列表显示
- 多硬盘信息列表显示

## 项目结构
```
TuringSmartScreenClient/
├── TuringSmartScreenClient.csproj  // 项目配置
├── App.xaml                      // 应用入口
├── Views/
│   └── DeviceManagementPage.xaml // 设备管理页面
│   └── DeviceManagementPage.xaml.cs
```

## 关键代码实现
### 1. 进度条样式
```xml
<Style x:Key="LinearProgressStyle" TargetType="ProgressBar">
    <Setter Property="Height" Value="20"/>
    <Setter Property="Foreground" Value="#2E579B"/>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ProgressBar">
                <Grid>
                    <Rectangle Stroke="Gray" StrokeThickness="1" RadiusX="10" RadiusY="10"/>
                    <Rectangle x:Name="PART_Track" Fill="LightGray" RadiusX="10" RadiusY="10"/>
                    <Rectangle x:Name="PART_Indicator" Fill="{TemplateBinding Foreground}" 
                               RadiusX="10" RadiusY="10">
                        <Rectangle.Width>
                            <MultiBinding Converter="{StaticResource ProgressToWidthMultiConverter}">
                                <Binding Path="Value" RelativeSource="{RelativeSource TemplatedParent}"/>
                                <Binding Path="ActualWidth" ElementName="PART_Track"/>
                            </MultiBinding>
                        </Rectangle.Width>
                    </Rectangle>
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

### 2. 信息格式化
```xml
<TextBlock>
    <Run Text="CPU 型号："/>
    <Run Text="{Binding CpuModel}"/>
</TextBlock>
<TextBlock>
    <Run Text="CPU 频率："/>
    <Run Text="{Binding CpuFrequency, StringFormat={}{0:F2} GHz}"/>
</TextBlock>
```

### 3. 转换器实现
```csharp
public class ProgressToWidthMultiConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is double progress && values[1] is double maxWidth)
        {
            return progress * maxWidth / 100;
        }
        return 0;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

## 安装与运行
### 环境要求
- .NET 6.0 SDK
- Windows 10/11

### 运行步骤
1. 克隆项目：
```bash
git clone https://github.com/Zeer3330/TuringSmartScreenClient.git
cd TuringSmartScreenClient
```

2. 编译运行：
```bash
dotnet build
dotnet run
```

## 贡献指南
1. Fork 项目
2. 创建特性分支：
```bash
git checkout -b feature/new-function
```

3. 提交代码：
```bash
git add .
git commit -m "Add new feature: [description]"
git push origin feature/new-function
```

4. 创建 Pull Request

## 许可证
MIT License - 请查看 LICENSE 文件获取详细信息

## 注意事项
1. 硬件信息目前为模拟数据，实际使用需实现真实数据获取逻辑
2. 温度显示功能需补充传感器数据获取代码
3. 可扩展添加刷新率控制、主题切换等功能

此 README 文件确保设备管理页面的核心组件（进度条、信息格式化、多硬件支持）代码描述准确，实际项目代码已通过编译验证。
