using BusinessObjects;
using Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService iProductService;
        private readonly ICategoryService iCategoryService;
        public MainWindow()
        {
            InitializeComponent();
            iProductService = new ProductService();
            iCategoryService = new CategoryService();
        }
        public void LoadCategoryList()
        {
            try
            {
                var carList = iCategoryService.GetCategories();
                cboCategory.ItemsSource = carList;
                cboCategory.DisplayMemberPath = "CategoryName"; // Assuming Category has a property CategoryName
                cboCategory.SelectedValuePath = "CategoryId"; // Assuming Category has a property CategoryId

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public void LoadProductList()
        {
            try
            {
                var productList = iProductService.GetProducts();
                var categoryList = iCategoryService.GetCategories();
                foreach(var product in productList)
                {
                    //Gán categoryName cho mỗi product từ categoryList
                    var category = categoryList.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                    if(category != null)
                    {
                        product.Category = category;
                    }
                }
                dgData.ItemsSource = null;
                dgData.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of products");
            }
            finally
            {
                resetInput();
            }
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                iProductService.SaveProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on create product");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra SelectedItem có phải là Product không
            if (dgData.SelectedItem is Product selectedProduct)
            {
                // Gán dữ liệu lên form, xử lý null an toàn
                txtProductID.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName ?? "";
                txtPrice.Text = selectedProduct.UnitPrice?.ToString() ?? "0";
                txtUnitsInStock.Text = selectedProduct.UnitsInStock?.ToString() ?? "0";
                cboCategory.SelectedValue = selectedProduct.CategoryId;
            }
        }
        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductId = Int32.Parse(txtProductID.Text);
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                iProductService.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on update product");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = Int32.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                    iProductService.DeleteProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on delete product");
            }
            finally
            {
                LoadProductList();
            }
        }
        private void resetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }
    }
}