using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BookStoreManagerController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        public ActionResult Search(string q)
        {
            var books = db.Books.Include("Author").Where(a => a.Title.Contains(q)).Take(10);
            return View(books);
        }
        // GET: BookStoreManager
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Genre);
            return View(books.ToList());
        }

        // GET: BookStoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: BookStoreManager/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: BookStoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,GenreId,AuthorId,Title,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", book.GenreId);
            return View(book);
        }

        // GET: BookStoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", book.GenreId);
            return View(book);
        }

        // POST: BookStoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,GenreId,AuthorId,Title,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", book.GenreId);
            return View(book);
        }

        // GET: BookStoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: BookStoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
